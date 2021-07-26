using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleFlow : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    //Rigidbody rg;

    //private bool isClick;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        //rg = GetComponent<Rigidbody>();
        //isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("´©¸§");
            ps.Play(true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("¼Õ¶À");
            ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }
}
