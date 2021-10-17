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
    public GameObject glow;

    // curtain
    public Transform other;
    private bool Close = false; // 왼쪽
    private bool Close2 = false; // 오른쪽
    private Animator curtain_animator = null;
    private Animator curtain_animator2 = null;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        curtain_animator = GameObject.Find("curtain_1").GetComponent<Animator>();
        curtain_animator2 = GameObject.Find("curtain_2").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            if(other) {
                float dist = Vector3.Distance(other.position, transform.position);
                Debug.Log("Distance to other : " + dist);
                if(dist <= 0.1f && CompareTag("L1")) {
                    Destroy(glow);
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            animator.SetBool("isDown", true);
                            curtain_animator.SetBool("Close", true);
                        }
                        else
                        {
                            animator.SetBool("isDown", false);
                            curtain_animator.SetBool("Close", false);
                        }
                    }
                }

                if (dist <= 0.1f && CompareTag("L2"))
                {
                    Destroy(glow);
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            animator.SetBool("isDown", true);
                            curtain_animator2.SetBool("Close2", true);
                        }
                        else
                        {
                            animator.SetBool("isDown", false);
                            curtain_animator2.SetBool("Close2", false);
                        }
                    }
                }
            }
        }
    }
}
