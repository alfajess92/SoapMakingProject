using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScriptWoodSaucer : MonoBehaviour
{
    //TODO this script maybe can be generic
    ParticleSystem waterStreamWoodSaucer;
    
    void Start()
    {
        waterStreamWoodSaucer = GetComponent<ParticleSystem>();
        StopWaterStreamWoodSaucer();
    }


    public void PlayWaterStreamWoodSaucer()//to add in the animator controller as a parameter
    {
        waterStreamWoodSaucer.Play();
    }

    public void StopWaterStreamWoodSaucer()
    {
        waterStreamWoodSaucer.Stop();
    }
}
