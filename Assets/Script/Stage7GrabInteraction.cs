using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Stage7GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    private bool isCut = false; // 버튼 초기 상태
    private bool buttonB = false;
    public GameObject glow;
    public Transform other;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            Destroy(glow);
            if (isCut != primary)
            {
                isCut = primary; // button on trigger
                if (isCut)
                {

                }
                else
                {

                }
            }
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primary2)) // Loading scene
        {
            buttonB = primary2;
            if (buttonB)
            {
                SceneManager.LoadScene("stage 1 SIMULATION");
            }
        }
    }
}
