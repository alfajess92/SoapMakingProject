﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScript : MonoBehaviour
{
    ParticleSystem waterStream;
    Transform teapotTransform;
    Vector3 position;
    AudioSource audioSource;
    public GameObject teapot;
    // Start is called before the first frame update
    void Start()
    {
        waterStream = GetComponent<ParticleSystem>();
        teapot = GameObject.Find("Teapot");
        teapotTransform = teapot.transform;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        //{
        //    waterStream.Play();

        //}
        //else
        //{
        //    waterStream.Stop();
        //}
        position = teapotTransform.localPosition;
        Debug.Log(position.y);
        if (position.y >=0.15f)
        {
            waterStream.Play();
            if (!audioSource.isPlaying)                    //if the audio is not playing

            {
                audioSource.Play();
            }
        }
        else
        {
            waterStream.Stop();
            audioSource.Stop();
        }
    }
}
