using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodSaucer : MonoBehaviour
{
   [SerializeField] SpillScriptWoodSaucer spill;
    Animator animatorWoodSaucer, animatorWaterAsh, animatorAsh;

    AudioSource audiosourceWoodSaucer;
    public GameObject waterAsh, ash;
    public bool isTouchWoodsaucer = false;
    public bool isEmpty = false;
    float woodSaucerClipLength;

    // Start is called before the first frame update
    void Start()
    {
        animatorWoodSaucer = GetComponent<Animator>();
        audiosourceWoodSaucer = GetComponent<AudioSource>();

        //waterAsh = GameObject.Find("WaterProDaytime");//is not needed
        animatorWaterAsh = waterAsh.GetComponent<Animator>();

        //ash= GameObject.Find("ash2");//is not needed
        animatorAsh = ash.GetComponent<Animator>();


        AnimationClip[] clipsWoodSaucer = animatorWoodSaucer.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsWoodSaucer)

        {
            woodSaucerClipLength = clip.length;
        }

        //AnimationClip[] clipsWaterAsh = animatorWaterAsh.runtimeAnimatorController.animationClips;

        //foreach (AnimationClip clip in clipsWaterAsh)

        //{
        //    waterAshClipLength = clip.length;
        //}



    }

    public void ServeWaterWoodSaucer()
    {
        //Debug.Log("echale");
        animatorWoodSaucer.SetTrigger("ServeAsh");

        //Called the bool condition only when the animation is finished
        print(woodSaucerClipLength);
        Invoke("TouchWoodSaucer", woodSaucerClipLength);
        //isTouchWoodsaucer = true;
       
    }

    public void TouchWoodSaucer()
    {
        isTouchWoodsaucer = true;
    }

    //Called from InputManager to restart the interactions
    public void UntouchWoodSaucer()
    {
        isTouchWoodsaucer = false;
    }





    //Methods called by the animator controller

    public void EmptyWoodSaucer()
    {
        animatorWaterAsh.SetTrigger("EmptyWoodSaucer");
    }

    //Methods called by the animator controller

    public void DissapearAsh()
    {
        animatorAsh.SetTrigger("Dissapear");
    }

    //Methods called by the animator controller

    public void PlayWaterStream()
    {
        spill.PlayWaterStreamWoodSaucer();
    }

    //Methods called by the animator controller

    public void StopWaterStream()
    {
        spill.StopWaterStreamWoodSaucer();
    }

    //Methods called by the animator controller

    public void PlaySoundWoodSaucerStream()//TODO check if this has to be here

    {
        if (!audiosourceWoodSaucer.isPlaying)                    //if the audio is not playing

        {
            audiosourceWoodSaucer.Play();
        }

        else

        {
            audiosourceWoodSaucer.Stop();
        }

    }




}
