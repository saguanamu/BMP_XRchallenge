using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class SimulationStage1Interaction : MonoBehaviour
{
    public XRController controller = null;
    private bool isDowned = false; // 버튼 초기 상태
    private bool buttonB = false;
    public GameObject glow;
    public Transform other;

    private Animator bt_start = null;
    private Animator bt_stop = null;
    private Animator[] plant = null;
    private Animator[] plant2 = null;
    private Animator[] plant3 = null;

    [SerializeField] public ParticleSystem water1;
    [SerializeField] public ParticleSystem water2;
    [SerializeField] public ParticleSystem water3;

    public GameObject display1;
    public GameObject display2;

    // Start is called before the first frame update
    void Start()
    {
        bt_start = GameObject.Find("button start").GetComponent<Animator>();
        bt_stop = GameObject.Find("button stop").GetComponent<Animator>();
        plant = GameObject.Find("grow plant").GetComponentsInChildren<Animator>();
        plant2 = GameObject.Find("grow plant 2").GetComponentsInChildren<Animator>();
        plant3 = GameObject.Find("grow plant 3").GetComponentsInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Debug.Log("Distance to other : " + dist);
            // 첫번째 온실하우스
            if (dist <= 0.02f && CompareTag("B3"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_start.SetBool("Push", true);
                            water1.Play();
                            water2.Play();
                            water3.Play();
                            display1.SetActive(false);
                            display2.SetActive(false);
                            Destroy(display2);
                            foreach (Animator a in plant)
                            {
                                a.SetBool("isGrow", true);
                            }
                        }
                        else
                        {
                            bt_start.SetBool("Push", false);
                            foreach (Animator a in plant)
                            {
                                a.SetBool("isGrow", false);
                            }
                        }
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("B5"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_stop.SetBool("Push", true);
                        }
                        else
                        {
                            bt_stop.SetBool("Push", false);
                            water1.Stop();
                            water2.Stop();
                            water3.Stop();
                        }
                    }
                }
            }

            // 두번째 온실하우스
            if (dist <= 0.02f && CompareTag("green2 start"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_start.SetBool("Push", true);
                            water1.Play();
                            water2.Play();
                            water3.Play();
                            display1.SetActive(false);
                            display2.SetActive(false);
                            Destroy(display2);
                            foreach (Animator b in plant2)
                            {
                                b.SetBool("isGrow", true);
                            }
                        }
                        else
                        {
                            bt_start.SetBool("Push", false);
                            foreach (Animator b in plant2)
                            {
                                b.SetBool("isGrow", false);
                            }
                        }
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("green2 stop"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_stop.SetBool("Push", true);
                        }
                        else
                        {
                            bt_stop.SetBool("Push", false);
                            water1.Stop();
                            water2.Stop();
                            water3.Stop();
                        }
                    }
                }
            }

            // 세번째 온실하우스
            if (dist <= 0.02f && CompareTag("green3 start"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_start.SetBool("Push", true);
                            water1.Play();
                            water2.Play();
                            water3.Play();
                            display1.SetActive(false);
                            display2.SetActive(false);
                            Destroy(display2);
                            foreach (Animator c in plant3)
                            {
                                c.SetBool("isGrow", true);
                            }
                        }
                        else
                        {
                            bt_start.SetBool("Push", false);
                            foreach (Animator c in plant3)
                            {
                                c.SetBool("isGrow", false);
                            }
                        }
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("green3 stop"))
            {
                Destroy(glow);
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_stop.SetBool("Push", true);
                        }
                        else
                        {
                            bt_stop.SetBool("Push", false);
                            water1.Stop();
                            water2.Stop();
                            water3.Stop();
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
                SceneManager.LoadScene("stage3 SIMULATION");
            }
        }
    }
}
