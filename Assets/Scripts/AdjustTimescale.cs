using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustTimescale : MonoBehaviour
{
    public GameObject TimeScaleAdjust;
    public Slider slider;
    public Text scaleDisplay;

    void Update()
    {
        scaleDisplay.text = $"Timescale: {System.Math.Round((double)slider.value, 2)}";
        TimeScaleAdjust.GetComponent<SlowMotion>().timeSpeed = (float)System.Math.Round((double)slider.value, 2);
    }
}
