using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMix : MonoBehaviour
{
   
private AudioSource audioSource;

public static AudioManagerMix current;

    private void Awake()
    {
        current = this;
    }


    public void PlaySound(AudioClip clip)
    {

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }

    public void StopSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }
}

