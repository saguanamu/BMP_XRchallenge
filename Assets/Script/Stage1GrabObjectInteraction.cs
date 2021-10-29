using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;

public class Stage1GrabObjectInteraction : MonoBehaviour
{
    public XRController controller = null;
    public AudioClip clip;

    // water animation
    private bool isWatered = false; // 물 뿌린 상태 초기값 false
    private bool buttonB = false;
    [SerializeField] private ParticleSystem ps;
    public GameObject glow;

    private void Start()
    {
        ps = GameObject.Find("WaterEffect").GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary))
        {
            Destroy(glow);
            if (isWatered != primary)
            {
                isWatered = primary; // button on trigger
                if (isWatered)
                {
                    ps.Play();
                    SoundManger.instance.SFXPlay("liquid", clip);
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
            if(buttonB) {
                SceneManager.LoadScene("stage2");
            }
        }
    }
    
}
