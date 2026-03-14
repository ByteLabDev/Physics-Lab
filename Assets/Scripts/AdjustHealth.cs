using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHealth : MonoBehaviour
{
    public HumanHealth healthWatcher;
    public float healthModifier = 1;
    [Range (0, 100)] public float dmg = 100;
    void OnCollisionEnter2D(Collision2D col) {
        if (col.relativeVelocity.magnitude > 35 && col.transform.parent != transform.parent){
            //hp = col.relativeVelocity.magnitude/10.5f;
            decimal colForce = (decimal)(col.relativeVelocity.magnitude / healthModifier);
            //float colForce = 57.61232f;
            //Debug.Log($"Colforce: {colForce}, {100 - Mathf.Round(colForce * 10.0f) * 0.1f}, {Mathf.Round(colForce * 10.0f) * 0.1f}");
            dmg = (float)System.Math.Round(colForce, 2);

            if(healthWatcher.hp - dmg <= 0){
                healthWatcher.hp = 0;
                return;
            }else{
                healthWatcher.hp -= dmg;
            }
        }
    }
}
