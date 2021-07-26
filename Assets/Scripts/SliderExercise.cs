using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderExercise : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private TextMeshProUGUI text;

    private void Awake()
    {
        slider.onValueChanged.AddListener(OnSliderEvent);
    }

    public void OnSliderEvent(float value)
    {
        text.text = $"Volume {value * 100:F1}%";
    }
}
