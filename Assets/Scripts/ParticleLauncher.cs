using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : MonoBehaviour
{

    public ParticleSystem particleLauncher;
    public GameObject liquid;
    //public VolumeManager volumeManager;//for container that is being filled
    //public VolumeManager volumeManager2;//for container that is being emptyed

    //To keep track of the number of particles 
    public static float drops;


    void Start()
    {
        particleLauncher = GetComponent<ParticleSystem>();
        drops = 0f;
    }

    public void OnParticleCollision(GameObject other)
    {
        ////to get the information about the particle collision events
        //volumeManager.AdjustVolume();
        //volumeManager2.AdjustVolume();
        ////print("changing volume");


    }


    // Update is called once per frame
    void Update()
    {
        //Allow to spawn  a certain number of particles when the function is called
        if (Input.GetButton("Jump"))
        {
            particleLauncher.Emit(1);// emit 1 particle everyframe
        }

        drops = particleLauncher.particleCount;
        //print("These drops are falling"+drops);


    }

    //From unity tutorial
    int GetAliveParticles()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleLauncher.particleCount];
        return particleLauncher.GetParticles(particles);
    }

}