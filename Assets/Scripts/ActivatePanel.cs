using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject WholePanel;
    private Vector3 mousePos;

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 26.30469f);
                WholePanel.transform.position = mousePos;
                panelUI.SetActive(true);
            }
        }
}
