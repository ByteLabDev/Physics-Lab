using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{

    public GameObject LoadPanel;
    public GameObject KillMenu;
    public int SceneIndex;
    private Color panelColor;
    private float panelColorAlpha;
    public bool loadStarted;

    public int acquiredLayer;
    public int unAcquireLayer;


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
        if (loadStarted == true)
        {
            LoadPanel.SetActive(true);
            if (panelColorAlpha < 1f)
            {
                panelColorAlpha += 0.05f;
                LoadPanel.GetComponent<Image>().color = new Color(panelColor.r, panelColor.g, panelColor.b, panelColorAlpha);
            }
            else
            {
                StartCoroutine(LoadNextScene());
            }
        }
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(1);
        KillMenu.SetActive(false);
        SceneManager.LoadScene(SceneIndex);
    }

    public void StartLoad()
    {
        loadStarted = true;
    }
}
