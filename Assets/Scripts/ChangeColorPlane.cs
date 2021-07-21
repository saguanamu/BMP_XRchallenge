using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorPlane : MonoBehaviour
{
    public Material pm;
    public Color color = new Color(63, 34, 21);
    public void setColorToBlack()
    {
        pm.SetColor("_Color", color);
    }
}
