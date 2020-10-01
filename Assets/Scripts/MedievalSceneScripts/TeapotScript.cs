using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Events;

public class TeapotScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;
    public GameObject  waterAsh;
    Animator animatorTeapot, animatorWaterAsh;
    AudioSource audioSource;
    public bool isTouchTeapot = false;
    float teapotClipLength;
 
    void Start()

    {
        //waterAsh = GameObject.Find("WaterLayer");

        //getting the animator attached to the water in the ash
        animatorWaterAsh = waterAsh.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //getting the animator of attached to the teapot
        animatorTeapot = gameObject.GetComponent<Animator>();

        //Fetch the current Animation clip information for the base layer
        AnimationClip[] clipsTeapot = animatorTeapot.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsTeapot)

        {
            teapotClipLength = clip.length;
        }


    }

    public void ServeWaterTeapot()
    {
        animatorTeapot.SetTrigger("Serve");//inside the animator controller
        //animatorWaterAsh.SetTrigger("Fill");

        //Called the bool condition only when the animation is finished
        print(teapotClipLength);
        Invoke("TouchTeapot", teapotClipLength);//
    }

    public void TouchTeapot()
    {
        isTouchTeapot = true;
    }

    //Called from InputManager to restart the interactions
    public void UntouchTeapot()
    {
        isTouchTeapot = false;
    }

    //Methods called by the animator controller

    public void PlayWaterStream()//to add in the animator controller as a parameter
    {
        spill.PlayStreamContainer();
    }


    public void FillContainer()
    {
        animatorWaterAsh.SetTrigger("Fill");
        

    }

    public void StopWaterStream()
    {
        spill.StopStreamContainer();
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
