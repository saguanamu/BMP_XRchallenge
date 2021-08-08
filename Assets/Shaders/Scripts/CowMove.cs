using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowMove : MonoBehaviour
{
    private float h = 0.0f; // 수평
    private float v = 0.0f; // 전진 후진
    private float moveSpeed = 10.0f; // 이동 속도
    private Transform playerTr; // 클래스여서
    
    private float r = 0.0f;
    private float rotationSpeed = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
        // add component 유니티에서 컨트롤 추가해야 연동됨

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        r = Input.GetAxis("Mouse X");
        //Debug.Log("H: " + h.ToString() + ", V: " + v.ToString());
        playerTr.Translate(new Vector3(h, 0, v) * moveSpeed * Time.deltaTime);
        //playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime); // 회전

    }
    public void OnCollisionEnter(Collision collision)
    {
        playerTr.Rotate(new Vector3(0, r, 0) * rotationSpeed * Time.deltaTime); // 회전
    }
}
