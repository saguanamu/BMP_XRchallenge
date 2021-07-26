using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticleFlow : MonoBehaviour
{
    // Start is called before the first frame update
    public ParticleSystem ps;
    //public GameObject particle;
    Rigidbody rg;

    //private bool isClick;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        rg = GetComponent<Rigidbody>();
        //ps.Pause();

        //ps.Play(false);
        //isClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("´©¸§");
            //particle.SetActive(!particle.activeSelf);
            //ParticleSystem particles = Instantiate(ps);
            ps.Play();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("¼Õ¶À");
            ps.Stop();
        }
    }
}
