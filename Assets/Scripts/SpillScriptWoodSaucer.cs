using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScriptWoodSaucer : MonoBehaviour
{
    ParticleSystem waterStreamWoodSaucer;
    // Start is called before the first frame update
    void Start()
    {
        waterStreamWoodSaucer = GetComponent<ParticleSystem>();
        StopWaterStream();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayWaterStream()
    {
        waterStreamWoodSaucer.Play();
    }

    public void StopWaterStream()
    {
        waterStreamWoodSaucer.Stop();
    }
}
