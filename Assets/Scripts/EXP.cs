using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXP : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Slider expbar;

    //private int maxEXP = 8;
    private float currentEXP = 0;

    private void Start()
    {
        //currentEXP = currentEXP + Land_ver_wet.exp;
        //expbar.value = (float)currentEXP * 0.125f;
        
    }

    private void Update()
    {
        if(currentEXP != Land_ver_wet.exp)
        {
            currentEXP++;
            Handle();
            //currentEXP = currentEXP + Land_ver_wet.exp;
        }
        
    }

    void Handle()
    {
        Debug.Log(currentEXP);
        expbar.value = (float)currentEXP / 8f;
    }
}
