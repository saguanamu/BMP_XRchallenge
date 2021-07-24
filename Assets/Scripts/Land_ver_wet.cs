using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land_ver_wet : MonoBehaviour
{
    public ParticleSystem part;
    MeshRenderer mesh;
    Material mat;
    public static int exp = 0;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        mesh = GetComponent<MeshRenderer>();
        mat = mesh.material;
    }

    private void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("충돌감지");
        if (other.tag == "Water")
        {
            Debug.Log("흙에 물이 닿았다.");
            Invoke("ColorChange", 3.0f);
        }

    }

    public void ColorChange()
    {
        if (mat.color != new Color(51 / 255f, 0 / 255f, 0 / 255f, 255 / 255f))
        {
            mat.color = new Color(51 / 255f, 0 / 255f, 0 / 255f, 255 / 255f);
            exp ++;
            print(exp);
        }
    }
}
