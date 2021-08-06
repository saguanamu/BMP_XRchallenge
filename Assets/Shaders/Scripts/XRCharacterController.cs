using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class XRCharacterController : MonoBehaviour
{
    // input values
    public float speed = 0.2f;

    // reference
    public Transform head = null;
    public Transform mesh = null;
    public XRController controller = null;

    // Componenets
    private Animator animator = null;
    private CharacterController character = null;

    // Values
    private Vector3 currentDirection = Vector3.zero;

    // 플레이어 주변 인식 가능한 물건
    GameObject nearObject;
    private bool isPicked = false;
    public GameObject[] pickys; // 주울 수 있는 물건들
    public bool[] hasPickys; // 플레이어가 주운 상태인지

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.enableInputActions)
        {
            CheckForMovement(controller.inputDevice);
            //CheckForWave(controller.inputDevice);
            Push(controller.inputDevice);
            //Interaction();
        }
    }

    private void CheckForMovement(InputDevice device) // joystick direction
    {
        // Look for input, and potential value
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 joystickDirection))
        {
            // Sets character direction, also factoring head
            CalculateDirection(joystickDirection);

            // Apply character direction, and speed v
            MoveCharacter();

            // Orient the character mesh seperately
            OrientMesh();

            // Animate blend tree
            Animate();
        }
    }


    private void CalculateDirection(Vector2 joystickDirection)
    {
        // Joystick direction
        Vector3 newDirection = new Vector3(joystickDirection.x, 0, joystickDirection.y);

        // Look rotate
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        // Rotate our joystick direction using the rotation of the head
        currentDirection = Quaternion.Euler(headRotation) * newDirection;
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

    
    // 미션 물건 인식
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Tool")
            nearObject = other.gameObject;
        Debug.Log(nearObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tool")
            nearObject = null;
    }
    
    
    // 미션 물건 줍기 or 들기
    /*
    void Interaction()
    {
        if(nearObject.tag == "Tool")
        {
            Item item = nearObject.GetComponent<Item>();
            int toolIndex = item.value;
            hasPickys[toolIndex] = true;

            Destroy(nearObject);
        }

    }*/


    private void Push(InputDevice device) // A button
    {
        // A Button
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary)) {
            if (nearObject.tag == "Tool")
            {
                Item item = nearObject.GetComponent<Item>();
                int toolIndex = item.value;
                hasPickys[toolIndex] = true;

                Destroy(nearObject);
            }
            /*
            if (isPicked != primary)
            {
                isPicked = primary;
                if (isPicked)
                {
                    animator.SetTrigger("Push");
                }
                else
                {
                    animator.ResetTrigger("Push");
                }
            }*/
        }
    }
}

