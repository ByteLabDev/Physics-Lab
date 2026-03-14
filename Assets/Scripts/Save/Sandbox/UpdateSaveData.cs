using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpdateSaveData : MonoBehaviour
{
    public GameObject lightObject;
    public Slider timeScaleReader;
    public GameObject nameTagReader;


    public bool isLight;
    public float timeScaleValue;
    public float[] gravScale;
    public bool nameTagVisible;

    public Slider xGrav;
    public Slider yGrav;
    public PauseMenu pauseMenu;
    public GameObject timeScaleScript;

    private void Update() {
        isLight = lightObject.GetComponent<ControlBar>().isLight;
        timeScaleValue = (float)System.Math.Round((double)timeScaleReader.value, 2);
        gravScale[0] = Physics2D.gravity.x;
        gravScale[1] = Physics2D.gravity.y;
        nameTagVisible = nameTagReader.GetComponent<ControlBar>().nameTag;
    }

    public void SavePlayer(){
        UserDataSaver.SaveUserData(this);
    }
    
    public void LoadPlayer(){
        UserSaveData data = UserDataSaver.LoadPlayer();

        //Toggle Light/Dark Mode
        if(data.isLight){ //If savedata says light mode
            if(lightObject.GetComponent<ControlBar>().isLight == false){ //If current state is dark
                lightObject.GetComponent<ControlBar>().ToggleBG(); //Swtch to light
            }
        }else{ //If savedata says dark mode
            if(lightObject.GetComponent<ControlBar>().isLight == true){ //If current state is light
                lightObject.GetComponent<ControlBar>().ToggleBG(); //Switch to dark
            }
        }

        //Change Gravity
        Physics2D.gravity = new Vector2(data.gravScale[0], data.gravScale[1]);
        xGrav.value = data.gravScale[0];
        yGrav.value = data.gravScale[1];


        //Toggle Nametags
        if(data.nameTagVisible){ //If savedata says nametags are enabled
            if(nameTagReader.GetComponent<ControlBar>().nameTag == false){ //If current state is disabled
                nameTagReader.GetComponent<ControlBar>().ToggleNametag(); //Swtch to enabled
            }
        }else{ //If savedata says nametags are disabled
            if(nameTagReader.GetComponent<ControlBar>().nameTag == true){ //If current state is enabled
                nameTagReader.GetComponent<ControlBar>().ToggleNametag(); //Switch to disabled
            }
        }

        //Change Slow Motion Timescale
        timeScaleReader.value = data.timeScaleValue;
        timeScaleScript.GetComponent<SlowMotion>().timeSpeed = data.timeScaleValue;
    }

    public void ReloadScene(){
        SavePlayer();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        pauseMenu.resumeGame();
        LoadPlayer();
    }
    
}
