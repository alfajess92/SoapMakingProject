using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeapotScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;

    public GameObject  waterAsh;
    public GameObject definedButton;

    Animator animator, animatorWaterAsh;
    AudioSource audioSource;
    public bool isTouchTeapot = false;

    //// Start is called before the first frame update
    void Start()

    {
        waterAsh = GameObject.Find("WaterProDaytime");
        animator = GetComponent<Animator>();
        animatorWaterAsh = waterAsh.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

 
    public void ServeWaterTeapot()
    {
        animator.SetTrigger("Serve");//inside the animator controller
        animatorWaterAsh.SetTrigger("Fill");
        isTouchTeapot = true;
    }

    public void PlayWaterStream()//to add in the animator controller as a parameter
    {
        spill.PlayWaterStreamTeapot();
    }

    public void StopWaterStream()
    {
        spill.StopWaterStreamTeapot();
    }



    public void PlaySoundTeapotStream()//TODO check if this has to be here

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
