using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableLand : MonoBehaviour
{
    public string Name;
    public Sprite Image;
    public string InteractText = "Press A to water";

    public virtual void OnInteract()
    {

    }
}
