using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScript : MonoBehaviour
{
    ParticleSystem waterStreamTeapot;
    //TODO this script maybe can be generic



    void Start()
    {
        waterStreamTeapot = GetComponent<ParticleSystem>();
        StopWaterStreamTeapot();

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


   


}
