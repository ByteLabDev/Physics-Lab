using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeepSourceImage : MonoBehaviour
{
    public Sprite sourceSprite;
    public Sprite originalSprite;
    public Image image;
    public string childCheck;

    
    public void SetSource(){
    image.sprite = sourceSprite;

        GameObject uiParent = transform.parent.gameObject;
        Transform[] allChildren = uiParent.transform.GetComponentsInChildren<Transform>();

        foreach(Transform child in allChildren){
            if(child.tag == childCheck && child.name != transform.name){
                child.GetComponent<Image>().sprite = originalSprite;
            }
        }
        
    }

    
}
