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

    // effect
    public GameObject glow;

    // 온도계
    GameObject th1;
    Animator thanim1;

    // 플레이어 주변 인식 가능한 물건 -> 레버
    GameObject nearObject;
    GameObject lever1;
    Animator leveranim1;
    GameObject lever2;
    Animator leveranim2;
    GameObject lever3;
    Animator leveranim3;

    // 커튼
    
    GameObject curtain1;
    Animator curtainanim1;
    GameObject curtain2;
    Animator curtainanim2;
    GameObject curtain3;
    Animator curtainanim3;

    /*
    public GameObject curtain4;
    Animator curtainanim4;
    public GameObject curtain5;
    Animator curtainanim5;
    public GameObject curtain6;
    Animator curtainanim6;

    public GameObject curtain7;
    Animator curtainanim7;
    public GameObject curtain8;
    Animator curtainanim8;
    public GameObject curtain9;
    Animator curtainanim9;
    */
    private bool isMeasured = false; 
    //private bool isOpened = false; 

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        character = GetComponent<CharacterController>();

        // lever
        lever1 = GameObject.FindGameObjectWithTag("Button");
        leveranim1 = lever1.GetComponent<Animator>();
        lever2 = GameObject.FindGameObjectWithTag("Button2");
        leveranim2 = lever2.GetComponent<Animator>();
        lever3 = GameObject.FindGameObjectWithTag("Button3");
        leveranim3 = lever3.GetComponent<Animator>();

        th1 = GameObject.FindGameObjectWithTag("T1");
        thanim1 = th1.GetComponent<Animator>();

        // curtain

        curtain1 = GameObject.FindGameObjectWithTag("C1");
        curtainanim1 = curtain1.GetComponent<Animator>();
        curtain2 = GameObject.FindGameObjectWithTag("C2");
        curtainanim2 = curtain2.GetComponent<Animator>();
        curtain3 = GameObject.FindGameObjectWithTag("C3");
        curtainanim3 = curtain3.GetComponent<Animator>();
        /*
        curtain4 = GameObject.FindGameObjectWithTag("C2");
        curtainanim4 = curtain4.GetComponent<Animator>();
        curtain5 = GameObject.FindGameObjectWithTag("C2");
        curtainanim5 = curtain5.GetComponent<Animator>();
        curtain6 = GameObject.FindGameObjectWithTag("C2");
        curtainanim6 = curtain6.GetComponent<Animator>();

        curtain7 = GameObject.FindGameObjectWithTag("C3");
        curtainanim7 = curtain7.GetComponent<Animator>();
        curtain8 = GameObject.FindGameObjectWithTag("C3");
        curtainanim8 = curtain8.GetComponent<Animator>();
        curtain9 = GameObject.FindGameObjectWithTag("C3");
        curtainanim9 = curtain9.GetComponent<Animator>();*/
    }

    private void Start()
    {
    }

    private void Update()
    {
        if (controller.enableInputActions)
        {
            CheckForMovement(controller.inputDevice);
            //Open(controller.inputDevice);
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

    // 미션 물건 인식
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Button")
            nearObject = other.gameObject;
        if (other.tag == "Button2")
            nearObject = other.gameObject;
        if (other.tag == "Button3")
            nearObject = other.gameObject;
        if (other.tag == "Door")
            nearObject = other.gameObject;
        Debug.Log(nearObject.name);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button")
            nearObject = null;
        if (other.tag == "Button2")
            nearObject = null;
        if (other.tag == "Button3")
            nearObject = null;
        if (other.tag == "Door")
            nearObject = null;
    }

    // Push Lever
    private void Push(InputDevice device) // B button
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primary))
        {
            if (isMeasured != primary)
            {
                isMeasured = primary; // button on trigger
                // 첫번째 버튼

                if (isMeasured)
                {
                    animator.SetTrigger("Push");

                    //leveranim1.SetBool("Down", true);
                    //curtainanim1.SetBool("Close", true);
                    //curtainanim2.SetBool("Close", true);
                    //curtainanim3.SetBool("Close", true);
                    //thanim1.SetBool("Down", true);
                }
                else
                {
                    animator.SetTrigger("Push");
                    leveranim1.SetBool("Down", false);
                    curtainanim1.SetBool("Close", false);
                    curtainanim2.SetBool("Close", false);
                    curtainanim3.SetBool("Close", false);
                    Destroy(glow);
                }
            }
        }
    }

    // Door Open
    /*
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
                }
                else
                {
                    animator.ResetTrigger("Open");
                }
            }
        }
    }
    */
}

