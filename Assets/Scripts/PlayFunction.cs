using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFunction : MonoBehaviour
{
    public Vector3 targetPosition;
    private Rigidbody2D rb;
    private Vector2 direction;
    private float moveSpeed = 1f;
    private Vector3 defPos;
    private Vector3 finalDes;

    public int acquiredLayer;
    public int unAcquireLayer;
    public GameObject human;

    private bool menuSelected = false;
    private bool animFinished = false;

    void Start()
    {
        defPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(acquiredLayer, unAcquireLayer, true);
    }

    public void toggleMenu()
    {
        if(menuSelected == false)
        {
            menuSelected = true;
        }
        else
        {
            menuSelected = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.layer == unAcquireLayer)
        {
            if (col.collider.gameObject == human)
            {
                col.collider.gameObject.layer = acquiredLayer;
            }
        }
    }

    IEnumerator disableAnimation()
    {
        yield return new WaitForSeconds(3);
        menuSelected = false;
        animFinished = true;
        finalDes = transform.position;
    }

    void Update()
    {
        if(menuSelected == true)
        {
            moveSpeed += 5;
            direction = (targetPosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
            StartCoroutine(disableAnimation());
        }
        else if(animFinished == true)
        {
            transform.position = finalDes;
        }
        else
        {
            transform.position = defPos;
        }
    }
}
