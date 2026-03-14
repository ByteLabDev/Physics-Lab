using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataLoader : MonoBehaviour
{
    public GameObject dataLoad;

    private void Start() {
        dataLoad.GetComponent<UpdateSaveData>().LoadPlayer();
    }
}
