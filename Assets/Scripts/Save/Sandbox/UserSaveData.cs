using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class UserSaveData
{
    public bool isLight;
    public bool nameTagVisible;
    public float timeScaleValue;
    public float[] gravScale;

    // Update is called once per frame
    public UserSaveData(UpdateSaveData dataUpdate)
    {
        isLight = dataUpdate.isLight;
        timeScaleValue = dataUpdate.timeScaleValue;
        gravScale = dataUpdate.gravScale;
        nameTagVisible = dataUpdate.nameTagVisible;
    }
}
