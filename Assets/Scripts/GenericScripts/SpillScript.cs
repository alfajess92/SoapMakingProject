using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScript : MonoBehaviour
{

    //This script controls the particle system attach to any container

    ParticleSystem StreamContainer;
 

    void Start()
    {
        StreamContainer = GetComponent<ParticleSystem>();
        StopStreamContainer();

    }

    public void PlayStreamContainer()
    {
        StreamContainer.Play();
        
    }

    public void StopStreamContainer()
    {
        StreamContainer.Stop();
    }


   


}
