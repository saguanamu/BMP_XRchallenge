using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
//using namespace UnityEngine.Input;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Transform characterBody;

    Animator animator;

    //private InputDevice targetDevice;

    public int speedForward = 12;
    public int speedSide = 6;

    private float dirX = 0;
    private float dirZ = 0;

    void Start()
    {
        /*
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        animator = characterBody.GetComponent<Animator>();

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }
        */
        characterBody = GetComponent<Transform>();
    }

    void Update()
    {
        MovePlayer();
    }



    void MovePlayer()
    {
        dirX = 0;
        dirZ = 0;
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(coord.x);
            var absY = Mathf.Abs(coord.y);

            if(absX > absY)
            {
                if (coord.x > 0)
                    dirX = +1;
                else
                    dirX = -1;
            }
            else
            {
                if (coord.y > 0)
                    dirZ = +1;
                else
                    dirZ = -1;
            }
        }
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);
        transform.Translate(moveDir * Time.smoothDeltaTime);

    }
}