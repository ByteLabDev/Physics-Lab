using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSlider : MonoBehaviour
{
    private float colorRed = 255;
    private float colorGreen = 255;
    private float colorBlue = 255;
    private string hexResult;


    public GameObject colorParent;
    public GameObject redSlider;
    public GameObject greenSlider;
    public GameObject blueSlider;
    public GameObject colorOutput;
    public string childIgnore;
    public Text textBox;


    void Update()
    {
        colorRed = redSlider.GetComponent<Slider>().value;
        colorGreen = greenSlider.GetComponent<Slider>().value;
        colorBlue = blueSlider.GetComponent<Slider>().value;
        colorOutput.GetComponent<Image>().color = new Color(colorRed, colorGreen, colorBlue, 1f);

        Color currentColor = new Color(colorRed, colorGreen, colorBlue, 1f);

        hexResult = ColorUtility.ToHtmlStringRGB(currentColor);

        textBox.text = "#"+hexResult;

        Transform[] allChildren = colorParent.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag != childIgnore)
            {
                child.GetComponent<Renderer>().material.color = currentColor;
            }
        }
    }
}
