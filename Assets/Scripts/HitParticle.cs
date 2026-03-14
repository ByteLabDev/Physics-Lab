using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour
{
    public float minimumVel;
    public ParticleSystem hitParticle;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        var main = hitParticle.main;
        hitParticle.startColor = rend.material.color;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > minimumVel)
        {
            Vector2 avgPoint = new Vector2();
            foreach (ContactPoint2D colCon in col.contacts)
            {
                avgPoint += colCon.point;
            }
            avgPoint /= col.contacts.Length;
            Vector2 hitPoint = col.contacts[0].point;
            hitParticle.transform.position = avgPoint;
            hitParticle.Play();
        }
    }
}
