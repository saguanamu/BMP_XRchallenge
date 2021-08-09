using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage2 : MonoBehaviour
{
    // input values
    public float speed = 0.15f;
    public float deadzone = 0.1f;

    // reference
    public Transform head = null;
    public Transform mesh = null;
    public XRController controller = null;

    // Componenets
    private Animator animator = null;
    private CharacterController character = null;

    // Values
    private Vector3 currentDirection = Vector3.zero;

    [SerializeField] ParticleSystem glow = null;

    // door animation
    private bool isOpened = false;
    public Animation dooranim = null;
    // thermometer animation
    private bool isMeasured = false;
    public Animation thermometeranim = null;
    // lever animation
    public Animation lever = null;
    // curtain animation
    public Animation curtain = null;

    // lever
    public GameObject[] group_lever;
    // curtain
    public GameObject[] group_curtain;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();
        dooranim = GetComponent<Animation>();
        thermometeranim = GetComponent<Animation>();
        lever = GetComponent<Animation>();
        curtain = GetComponent<Animation>();
    }

    private void Update()
    {
        if (controller.enableInputActions)
        {
            CheckForMovement(controller.inputDevice);
            Open(controller.inputDevice);
            Push(controller.inputDevice);
        }
    }

    private void CheckForMovement(InputDevice device) // joystick direction
    {
        // Look for input, and potential value
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickDirection))
        {
            // Sets character direction, also factoring head
            Vector3 newDirection = CalculateDirection(joystickDirection);

            currentDirection = newDirection.magnitude > deadzone ? newDirection : Vector3.zero;

            // Apply character direction, and speed v
            MoveCharacter();

            // Orient the character mesh seperately
            OrientMesh();

            // Animate blend tree
            Animate();
        }
    }


    private Vector3 CalculateDirection(Vector2 joystickDirection)
    {
        // Joystick direction
        Vector3 newDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);

        // Look rotate
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        // Rotate our joystick direction using the rotation of the head
        return Quaternion.Euler(headRotation) * newDirection;
    }

    private void MoveCharacter() // head rotation
    {
        Vector3 movement = currentDirection * speed;

        character.SimpleMove(movement);
    }

    private void OrientMesh()
    {
        if (currentDirection != Vector3.zero)
            mesh.transform.forward = currentDirection;
    }

    private void Animate()
    {
        float blend = currentDirection.magnitude;
        animator.SetFloat("Move", blend);
    }



    // Push Lever
    private void Push(InputDevice device) // B button
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primary))
        {
            if (isMeasured != primary)
            {
                isMeasured = primary; // button on trigger
                if (isMeasured)
                {
                    animator.SetTrigger("Push");
                    lever.Play();
                }
                else
                {
                    animator.SetTrigger("Push");
                    lever.Stop();
                    Destroy(glow);
                }
            }
        }
    }

    // Door Open
    private void Open(InputDevice device) // A button
    {
        // A Button
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if (isOpened != primary)
            {
                isOpened = primary; // button on trigger
                if (isOpened)
                {
                    animator.SetTrigger("Open");
                    dooranim.Play();
                }
                else
                {
                    animator.ResetTrigger("Open");
                    dooranim.Stop();
                }
            }
        }
    }
}

