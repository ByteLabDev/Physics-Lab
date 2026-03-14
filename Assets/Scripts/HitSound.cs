using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSound : MonoBehaviour
{
    public float dropCol;
    public float smackCol;
    public AudioClip[] drops;
    public AudioClip[] smacks;
    public AudioListener audioListener;
    public GameObject objParent;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void smackAudio()
    {
        audioSource.clip = smacks[Random.Range(0, smacks.Length)];
        audioSource.Play();
    }

    void dropAudio()
    {
        audioSource.clip = drops[Random.Range(0, drops.Length)];
        audioSource.Play();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.parent.name != "Objects")
        {
            if (!audioSource.isPlaying || audioSource.clip.name.StartsWith("Drop"))
            {
                if (col.relativeVelocity.magnitude > dropCol)
                {
                    if (col.relativeVelocity.magnitude > smackCol)
                    {
                        smackAudio();
                    }
                    else if(!audioSource.isPlaying)
                    {
                        dropAudio();
                    }
                }
            }
        }
        

        //collision.relativeVelocity.magnitude
    }
}
