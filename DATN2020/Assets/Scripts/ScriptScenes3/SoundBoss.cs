using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundBoss : MonoBehaviour
{
    public AudioSource boom;
    void Start()
    {
        boom = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Boom()
    {
        boom.Play();
    }
}
