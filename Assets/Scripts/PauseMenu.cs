using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject menuPanel;
    public int MenuIndex;
    private float timeSpeedVar;
    public GameObject uiParent;
    private int restoreMask;
    public GameObject savePoint;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuPanel.activeSelf)
            {
                //Resume
                
                //Restore UI
                uiParent.SetActive(true);
                Camera.main.cullingMask = restoreMask;


                menuPanel.SetActive(false);
                Time.timeScale = timeSpeedVar;
            }
            else
            {
                //Pause

                //Set UI Restore
                restoreMask = Camera.main.cullingMask;

                //Disable UI
                uiParent.SetActive(false);
                Camera.main.cullingMask = ~(1 << LayerMask.NameToLayer("UI"));

                timeSpeedVar = Time.timeScale;
                menuPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void resumeGame()
    {
        menuPanel.SetActive(false);
        Time.timeScale = timeSpeedVar;
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene(MenuIndex);
        Time.timeScale = 1;
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
