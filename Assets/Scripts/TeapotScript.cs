using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeapotScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;

    public GameObject  waterAsh;
   

    Animator animatorTeapot, animatorWaterAsh;
    AudioSource audioSource;
    public bool isTouchTeapot = false;

    //string clipName;
    //AnimatorStateInfo animationState;
    //AnimatorClipInfo[] animatorClipInfo;
    float teapotClipLength, waterAshClipLength;
 


    //// Start is called before the first frame update
    void Start()

    {
        waterAsh = GameObject.Find("WaterProDaytime");

        //getting the animator attached to the water in the ash
        animatorWaterAsh = waterAsh.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //getting the animator of attached to the teapot
        animatorTeapot = gameObject.GetComponent<Animator>();


        //Fetch the current Animation clip information for the base layer
        //AnimatorClipInfo[] animatorClipInfo= this.animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip[] clipsTeapot = animatorTeapot.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsTeapot)

        {
            teapotClipLength = clip.length;
        }

        //AnimationClip[] clipsWaterAsh= animatorWaterAsh.runtimeAnimatorController.animationClips;

        //foreach (AnimationClip clip in clipsTeapot)

        //{
        //    waterAshClipLength = clip.length;
        //}

        //Access the current length of the clip and name
        ////currentClipLength = animatorClipInfo[0].clip.length;
        //clipName = animatorClipInfo[0].clip.name;

        //animationState = animator.GetCurrentAnimatorStateInfo(0);

    }


    public void ServeWaterTeapot()
    {
        animatorTeapot.SetTrigger("Serve");//inside the animator controller
        animatorWaterAsh.SetTrigger("Fill");
        //isTouchTeapot = true;

        //Called the bool condition only when the animatin is finished
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
        spill.PlayWaterStreamTeapot();
    }

    //Methods called by the animator controller

    public void StopWaterStream()
    {
        spill.StopWaterStreamTeapot();
    }

    //Methods called by the animator controller

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
