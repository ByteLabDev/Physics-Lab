using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    public float timeSpeed = 0.5f;
    private float fixedDeltaTime = 0;

    void Update()
    {
        if (Input.GetButtonDown("SlowMotion"))
        {
            if(Time.timeScale == 1f){
                Time.timeScale = timeSpeed;
            }else{
                Time.timeScale = 1f;
            }
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }
}
