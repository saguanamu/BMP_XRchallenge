using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever_Down : MonoBehaviour
{
    GameObject player;
    Animator anim;
    bool isPlayerEnter; // Player가 범위 안에 왔는지를 판별할 bool 타입 변수
    //public XRController controller = null;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("P");
        //anim = GetComponentInChildren<Animator>();
        anim = GetComponent<Animator>();
        isPlayerEnter = false;
    }

    void Update()
    {
        // 플레이어가 범위 안에 있고 B버튼을 누른다면
        if (isPlayerEnter)
        {
            // bool -> true
            anim.SetBool ("Down", true);
        }

    }
    // 콜라이더를 가진 객체가 (트리거옵션이 체크된)콜라이더 범위 안으로 들어왔고 그게 플레이어라면 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = true;
            Debug.Log("플레이어와 충돌");
        }
    }
    // 콜라이더를 가진 객체가 콜라이더 범위 밖으로 나갔고 그 객체가 플레이어라면
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerEnter = false;
        }
    }
}
