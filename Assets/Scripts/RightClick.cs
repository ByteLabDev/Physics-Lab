using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightClick : MonoBehaviour
{
    public GameObject ClickPanel;
    //public GameObject WholePanel;
    public GameObject ColorPanel;
    public Camera orthoCamera;
    public GameObject nameTag;
    public GameObject healthBar;
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HideIfClickedOutside(ClickPanel);
    }

    void HideIfClickedOutside(GameObject panel)
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                Camera.main))
        {
            panel.SetActive(false);
        }
    }

    public void toggleColor()
    {
        ColorPanel.SetActive(true);
        ClickPanel.SetActive(false);
    }

    public void ToggleNametag()
    {
        if (nameTag.activeSelf)
        {
            nameTag.SetActive(false);
        }
        else
        {
            nameTag.SetActive(true);
        }

        ClickPanel.SetActive(false);
    }

    public void ToggleHealth(){
        if (healthBar.activeSelf)
        {
            healthBar.SetActive(false);
        }
        else
        {
            healthBar.SetActive(true);
        }

        ClickPanel.SetActive(false);
    }
}
