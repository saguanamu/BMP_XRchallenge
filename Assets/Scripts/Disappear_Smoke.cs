using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear_Smoke : MonoBehaviour
{
    public ParticleSystem part;
    public ParticleSystem smoke;
    MeshRenderer mesh;
    Material mat;
    //public static int exp = 0;

    void Start()
    {
        part = GetComponent<ParticleSystem>(); // water
        smoke = GetComponent<ParticleSystem>();
    }

    private void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("충돌감지");
        if (other.tag == "Water")
        {
            Debug.Log("김이 사라진다.");
            smoke.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }

    }
}
