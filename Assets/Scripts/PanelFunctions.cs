using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFunctions : MonoBehaviour
{
    public GameObject killPanel;

    public void ClosePanel()
    {
        killPanel.SetActive(false);
    }
}
