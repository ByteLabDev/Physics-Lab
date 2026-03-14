using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalLoad : MonoBehaviour
{

    public GameObject LoadPanel;
    private Color panelColor;
    private float panelColorAlpha;


    void Start()
    {
        //panelColor = LoadPanel.GetComponent<Image>().color;
        //loadStarted = false;
        panelColor = LoadPanel.GetComponent<Image>().color;
        panelColorAlpha = panelColor.a;

    }

    // Update is called once per frame
    void Update()
    {
            
            if (panelColorAlpha > 0.01f)
            {
                panelColorAlpha -= 0.05f;
                LoadPanel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, panelColorAlpha);
            }
            else
            {
                LoadPanel.SetActive(false);
        }
    }







}
