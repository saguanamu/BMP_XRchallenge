using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1GrabObjectInteraction : MonoBehaviour
{
    public AudioClip audioClip;
    public AudioSource audioSource;
    public ParticleSystem particleSystemLiquid;

    [Header("Audio")]
    public AudioClip PouringClip;
    AudioSource m_AudioSource;
    public void Water()
    {
        particleSystemLiquid.Stop();

    }


    void Update()
    {
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            if (particleSystemLiquid.isStopped)
            {
                particleSystemLiquid.Play();
                m_AudioSource.Play();
            }

        }
        else
        {
            particleSystemLiquid.Stop();
            m_AudioSource.Stop();
        }
    }
    }
