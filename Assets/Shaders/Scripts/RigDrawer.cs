using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RigDrawer : MonoBehaviour
{
    public GameObject origin = null;
    private void OnDrawGizmos()
    {
        if(origin != null){
            Gizmos.color = Color.green;
            GizmoHelpers.DrawWireCubeOriented(origin.transform.position, origin.transform.rotation, 1.5f * origin.transform.localScale.x);
        }
    }
}
