using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimulationStage1Interaction : MonoBehaviour
{
    public XRController controller = null;
    private bool isDowned = false; // 버튼 초기 상태
    public GameObject glow;
    public Transform other;

    private Animator bt_start = null;
    private Animator bt_stop = null;
    private Animator plant = null;

    [SerializeField] public ParticleSystem water1;
    [SerializeField] public ParticleSystem water2;
    [SerializeField] public ParticleSystem water3;

    // Start is called before the first frame update
    void Start()
    {
        bt_start = GameObject.Find("button start").GetComponent<Animator>();
        bt_stop = GameObject.Find("button stop").GetComponent<Animator>();
        plant = GameObject.Find("PlantGrow").GetComponent<Animator>();
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
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            bt_start.SetBool("Push", true);
                            water1.Play();
                            water2.Play();
                            water3.Play();
                            plant.SetBool("isGrow", true);
                        }
                        else
                        {
                            bt_start.SetBool("Push", false);
                            plant.SetBool("isGrow", false);
                        }
                    }
                }
            }

            if (dist <= 0.05f && CompareTag("B5"))
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
    }
}
