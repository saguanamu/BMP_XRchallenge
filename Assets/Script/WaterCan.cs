using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterCan : Stage1
{
    private bool IsWater = false;
    public ParticleSystem water;


    public override void OnInteract()
    {
        if(controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool primary)) {  // A button trigger
            IsWater = !IsWater;
            GetComponent<Animator>().SetBool("water", true);
            water.Play();
            GetComponent<Animator>().SetBool("water", false);
            water.Stop();
        }
    }
}
