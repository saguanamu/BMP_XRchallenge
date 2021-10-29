using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SimulationStage3 : MonoBehaviour
{
    private Text digit = null;
    public float time = 9f;
    private float selectCountdown;

    private Animator fan = null;
    private Animator fan2 = null;
    private Animator fan3 = null;
    private Animator fan4 = null;

    private Animator rabbit1 = null;
    private Animator rabbit2 = null;
    private Animator rabbit3 = null;

    // Start is called before the first frame update
    void Start()
    {
        digit = GameObject.Find("Text").GetComponent<Text>();
        fan = GameObject.Find("stage 3 smart barn controller fan").GetComponent<Animator>();
        rabbit1 = GameObject.Find("WhiteRabbit1").GetComponent<Animator>();
        rabbit2 = GameObject.Find("WhiteRabbit2").GetComponent<Animator>();
        rabbit3 = GameObject.Find("WhiteRabbit3").GetComponent<Animator>();
        selectCountdown = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Floor(selectCountdown) == 25)
        {
            fan.SetBool("Rotate", true);
            Invoke("rabbitawake", 5);
        }
        else
        {
            selectCountdown += Time.deltaTime;
            digit.text = Mathf.Floor(selectCountdown).ToString();
        }
    }

    void rabbitawake()
    {
        rabbit1.SetBool("Ok", true);
        rabbit2.SetBool("Ok", true);
        rabbit3.SetBool("Ok", true);
    }
}
