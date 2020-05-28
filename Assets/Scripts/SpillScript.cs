using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScript : MonoBehaviour
{
    ParticleSystem waterStreamTeapot;
    //TODO this script maybe can be generic

    //Transform teapotTransform;
    //Vector3 position, rotation;
    ////Quaternion rotation;
    //AudioSource audioSource;
    //public GameObject teapot;

    void Start()
    {
        waterStreamTeapot = GetComponent<ParticleSystem>();
        StopWaterStreamTeapot();
        //teapot = GameObject.Find("Teapot");
        //teapotTransform = teapot.transform;
        //audioSource = GetComponent<AudioSource>();

    }

    public void PlayWaterStreamTeapot()
    {
        Debug.Log("vengase el agua");
        waterStreamTeapot.Play();
        Debug.Log("Ya eche el agua");
    }

    public void StopWaterStreamTeapot()
    {
        waterStreamTeapot.Stop();
    }


    // Update is called once per frame
    //void Update()
    //{
    //    //position = teapotTransform.localPosition; 
    //    Debug.Log("vengase el agua");
    //    rotation = teapotTransform.localEulerAngles;

    //    Debug.Log(rotation.x);
    //    //if (position.y ==0.151f)
    //    if (rotation.x>=271.0f)
    //    {
    //        waterStream.Play();
    //        if (!audioSource.isPlaying)  //if the audio is not playing

    //        {
    //            audioSource.Play();
    //        }
    //    }
    //    else

    //    {
    //        waterStream.Stop();
    //        audioSource.Stop();
    //    }
    //}



    //public void TeapotStream()
    // {
    //     Debug.Log("vengase el agua");
    //     rotation = teapotTransform.localEulerAngles;
    //     Debug.Log(rotation.x);

    //     //if (position.y ==0.151f)
    //     if (rotation.x >= 271.0f)
    //     {
    //         waterStreamTeapot.Play();
    //         if (!audioSource.isPlaying)  //if the audio is not playing

    //         {
    //             audioSource.Play();
    //         }
    //     }
    //     else

    //     {
    //         waterStreamTeapot.Stop();
    //         audioSource.Stop();
    //     }

    //     Debug.Log("Ya eche el agua");
    // }


}
