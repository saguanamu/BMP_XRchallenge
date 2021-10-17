using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage4GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    private bool isPushed = false; // 버튼 초기 상태
    public GameObject glow;
    public Transform other;
    //public Animator btn;
    //public Animator 온도계

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if (isPushed != primary)
            {
                isPushed = primary; // button on trigger
                if (isPushed)
                {
                }
                else
                {   
                }
            }
        }
    }
}
