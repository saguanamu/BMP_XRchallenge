using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;


public class Stage5GrabInteraction : MonoBehaviour
{
    public XRController controller = null;

    // water animation
    private bool isFeed = false; // 사료 뿌린 상태 초기값 false
    private bool buttonB = false;
    [SerializeField] private ParticleSystem ps;
    public GameObject glow;

    private Animator cow1 = null;
    private Animator cow2 = null;

    

    private void Start()
    {
        ps = GameObject.Find("FeedEffect").GetComponent<ParticleSystem>();
        cow1 = GameObject.Find("Cow (1)").GetComponent<Animator>();
        cow2 = GameObject.Find("Cow (2)").GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            Destroy(glow);
            if (isFeed != primary)
            {
                isFeed = primary; // button on trigger
                if (isFeed)
                {
                    Destroy(glow);
                    ps.Play();
                    cow1.SetBool("Eat", true);
                    cow2.SetBool("Eat", true);
                }
                else
                {
                    ps.Stop();
                }
            }
        }

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.secondaryButton, out bool primary2)) // Loading scene
        {
            buttonB = primary2;
            if (buttonB)
            {
                LoadingSceneManager.LoadScene("stage6");
            }
        }
    }
}
