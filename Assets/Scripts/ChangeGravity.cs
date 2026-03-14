using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeGravity : MonoBehaviour
{

    public Text xGravText;
    public Text yGravText;
    public Slider xGravSlide;
    public Slider yGravSlide;

    void Update()
    {
        Physics2D.gravity = new Vector3((float)System.Math.Round(xGravSlide.value, 2), (float)System.Math.Round(yGravSlide.value, 2), 0f);

        xGravText.text = "X: " + System.Math.Round(xGravSlide.value, 2);
        yGravText.text = "Y: " + System.Math.Round(yGravSlide.value, 2);
    }

    public void ResetGrav()
    {
        xGravSlide.value = 0f;
        yGravSlide.value = -7.81f;
        Physics2D.gravity = new Vector3(0f, -7.81f, 0f);
    }
}
