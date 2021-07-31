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

    private InputDevice targetDevice;

    void Start()
    {
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
    }

    void Update()
    {
       
    }

    /*private void Move()
    {
       
    }*/
}
