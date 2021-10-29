using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Stage4_GrabInteraction : MonoBehaviour
{
    public XRController controller = null;
    private bool isPushed = false; // 버튼 초기 상태
    private bool buttonB = false;

    public GameObject glow;
    public Transform other;
    public Animator heater;

    private Animator horse1 = null;
    private Animator horse2 = null;
    private Animator horse3 = null;
    private Animator horse4 = null;

    void Start()
    {
        horse1 = GameObject.Find("Horse").GetComponent<Animator>();
        horse2 = GameObject.Find("Horse (1)").GetComponent<Animator>();
        horse3 = GameObject.Find("Horse_White").GetComponent<Animator>();
        horse4 = GameObject.Find("Horse_White (1)").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Debug.Log("Distance to other : " + dist);
            if (dist <= 0.05f && CompareTag("B3"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isPushed != primary)
                    {
                        isPushed = primary; // button on trigger
                        if (isPushed)
                        {
                            heater.SetBool("Rotate", true);
                        }
                        else
                        {
                            Invoke("horseawake", 10);
                        }
                    }
                }
            }
        }


        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primary2)) // Loading scene
        {
            buttonB = primary2;
            if (buttonB)
            {
                SceneManager.LoadScene("stage5");
            }
        }
    }

    void horseawake()
    {
        horse1.SetBool("IsWarm", true);
        horse2.SetBool("IsWarm", true);
        horse3.SetBool("IsWarm", true);
        horse4.SetBool("IsWarm", true);
    }
}
