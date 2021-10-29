using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SimulationStage6 : MonoBehaviour
{
    public XRController controller = null;
    private bool isDowned = false; // 버튼 초기 상태
    private bool buttonB = false;
    private Animator wheel = null;
    private Transform backhoe = null;
    public Transform other;

    public GameObject start;
    public GameObject stop;
    public GameObject field_start;
    public GameObject field_stop;
    private Animator velocity;
    private GameObject[] plant;
    private GameObject[] plant2;
    private GameObject[] plant3;

    [SerializeField] public ParticleSystem water1;

    // Start is called before the first frame update
    void Start()
    {
        backhoe = GameObject.Find("Backhoe_01").GetComponent<Transform>();
        wheel = GameObject.Find("Wheel Meshes").GetComponentInChildren<Animator>();
        velocity = GameObject.Find("velocity").GetComponent<Animator>();
        plant = GameObject.Find("Garden_08(3)").GetComponentsInChildren<GameObject>();
        plant2 = GameObject.Find("Garden_07 (3)").GetComponentsInChildren<GameObject>();
        plant3 = GameObject.Find("Garden_05 (6)").GetComponentsInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            Debug.Log("Distance to other : " + dist);
            if (dist <= 0.02f && CompareTag("B3"))
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            wheel.SetBool("Rotate", true);
                            velocity.SetBool("On", true);
                            backhoe.position = new Vector3(-0.515f, 1.141f, 4.062f);
                        }
                        velocity.SetBool("On", false);
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("B5"))
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            wheel.SetBool("Rotate", false);
                            
                        }
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("L1"))
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            water1.Play();
                        }
                    }
                }
            }

            if (dist <= 0.02f && CompareTag("L2"))
            {
                if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
                {
                    if (isDowned != primary)
                    {
                        isDowned = primary; // button on trigger
                        if (isDowned)
                        {
                            water1.Stop();
                        }
                    }
                }
            }
        }
    }
}
