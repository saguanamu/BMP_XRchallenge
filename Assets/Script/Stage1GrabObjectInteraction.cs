using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Stage1GrabObjectInteraction : MonoBehaviour
{
    //private XRGrabInteractable grab = null;
    public XRController controller = null;
    public AudioClip clip;

    // water animation
    private bool isWatered = false; // 물 뿌린 상태 초기값 false
    [SerializeField] public ParticleSystem ps;
    public GameObject glow;

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
    }

    
}
