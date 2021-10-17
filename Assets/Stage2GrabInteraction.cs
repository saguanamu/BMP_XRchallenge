using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage2GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    public Animator animator = null;
    private bool isDowned = false; // 버튼 초기 상태

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if (isDowned != primary)
            {
                isDowned = primary; // button on trigger
                if (isDowned)
                {
                    animator.SetBool("isDown", true);
                }
                else
                {
                    animator.SetBool("isDown", false);
                }
            }
        }
    }
}
