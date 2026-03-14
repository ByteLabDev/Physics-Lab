using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBar : MonoBehaviour
{
    public GameObject BG1;
    public GameObject BG2;
    public GameObject GravPanel;
    public GameObject spawnPanel;
    public GameObject timePanel;
    private int restoreMask;
    public bool nameTag = true;
    public bool isLight = false;

    public void ToggleBG()
    {
        if (isLight)
        {
            BG1.SetActive(false);
            BG2.SetActive(true);
            isLight = false;
        }
        else
        {
            BG1.SetActive(true);
            BG2.SetActive(false);
            isLight = true;
        }
    }

    public void ToggleGravityPanel()
    {
        GravPanel.SetActive(true);
    }

    public void ToggleSpawner()
    {
        spawnPanel.SetActive(true);
    }

    public void ToggleTime(){
        timePanel.SetActive(true);
    }

    public void ToggleNametag(){
        if(nameTag){
            //Disable Nametag
            restoreMask = Camera.main.cullingMask;
            Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer("UI"));
            nameTag = false;
        }else{
            Camera.main.cullingMask = restoreMask;
            nameTag = true;
        }
    }
}
