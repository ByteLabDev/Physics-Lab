using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRigidbody : MonoBehaviour
{

    private Vector3 mousePosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 100f;
    private float totalWeight;
    public Vector3 offset;
    public string childIgnore;
    public GameObject rbParent;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Transform[] allChildren = rbParent.transform.GetComponentsInChildren<Transform>();
        foreach (Transform child in allChildren)
        {
            if (child.tag != childIgnore)
            {
                totalWeight += child.GetComponent<Rigidbody2D>().mass/10;
            }
        }
    }

    void OnMouseDown()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = new Vector3(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y, 0);
        
    }

    void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - offset - transform.position).normalized;
        rb.velocity = new Vector2((direction.x) * moveSpeed, (direction.y) * moveSpeed);
    }
}
