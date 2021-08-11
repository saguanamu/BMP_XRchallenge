using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControll : MonoBehaviour
{
    Animator Door_Controller;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("¹®¿¡ ´ê¾Ò´Ù.");
        Door_Controller.SetBool("IsOpening", true);
        
    }

    private void OnTriggerExit(Collider other)
    {
        Door_Controller.SetBool("IsOpening", false);
    }
    // Start is called before the first frame update
    void Start()
    {
        Door_Controller = this.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
