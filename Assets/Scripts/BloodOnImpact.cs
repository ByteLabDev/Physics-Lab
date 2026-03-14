using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodOnImpact : MonoBehaviour
{
    public float minimumVel;
    public ParticleSystem BloodParticle;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > minimumVel)
        {
            if (col.transform.parent != this.transform.parent)
                BloodParticle.Play();
        }
    }
}
