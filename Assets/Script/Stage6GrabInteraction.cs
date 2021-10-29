using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage6GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    private bool isDowned = false; // 버튼 초기 상태
    public GameObject glow;
    public Transform other;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Debug.Log("Distance to other : " + dist);
            if (dist <= 0.05f && CompareTag("Plant1"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            if (dist <= 0.05f && CompareTag("Plant2"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            if (dist <= 0.05f && CompareTag("Plant3"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }

            if (dist <= 0.05f && CompareTag("Plant4"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {

                        }
                        else
                        {

                        }
                    }
                }
            }
        }
    }
}
