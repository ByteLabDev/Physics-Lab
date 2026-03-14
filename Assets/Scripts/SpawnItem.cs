using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnItem : MonoBehaviour
{
    public GameObject itemPanel;
    public GameObject spawnItem;
    private Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetButtonDown("SpawnItem")){
            if(!itemPanel.activeSelf) return;
            foreach(Transform child in itemPanel.transform.GetComponentInChildren<RectTransform>()){
                var spawnObj = child.GetComponent<Toggle>();
                if(spawnObj.isOn && spawnObj.tag == "SelectBox"){
                    foreach(Transform spawn in spawnItem.GetComponentInChildren<Transform>()){
                        if(spawn.name == spawnObj.name){
                            Instantiate(spawn, new Vector3(mousePos.x, mousePos.y, 0), new Quaternion(0, 0, 0, 0));
                        }
                    }
                    
                }
            }
        }
    }
}
