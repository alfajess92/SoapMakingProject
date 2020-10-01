using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    
    }


    public void PlayAudioSource()
    {
        if (!audioSource.isPlaying)                    //if the audio is not playing

        {
            audioSource.Play();
        }

        else

        {
            audioSource.Stop();
        }
    }

}
