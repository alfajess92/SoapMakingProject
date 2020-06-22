using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBoilerScript : MonoBehaviour
{
    [SerializeField]

    SpillScriptOil spill;

    public GameObject oilLayer, oilLayerBigBoiler;


    Animator animatorMediumBoiler, animatorBigBoiler, animatorOilLayer;
    AudioSource audioSource;
    public bool isTouchMediumBoiler = false;

    
    float mediumBoilerClipLength;



    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //getting the animator of attached to the mediumboiler
        animatorBigBoiler = oilLayerBigBoiler.GetComponent<Animator>();
        animatorMediumBoiler = gameObject.GetComponent<Animator>();
        animatorOilLayer = oilLayer.GetComponent<Animator>();

        //Fetch the current Animation clip information for the base layer
        AnimationClip[] clipsTeapot = animatorMediumBoiler.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsTeapot)

        {
            mediumBoilerClipLength = clip.length;
        }

    }


    public void ServeOilBoiler()
    {
        animatorMediumBoiler.SetTrigger("Serve");//inside the animator controller
      //TODO check if this animation can be called from animator controller as event
       
        //Called the bool condition only when the animatin is finished
        print(mediumBoilerClipLength);
        Invoke("TouchMediumBoiler", mediumBoilerClipLength);//Touch after the animation is done
    }



    public void TouchMediumBoiler()
    {
        isTouchMediumBoiler = true;
    }


    //Called from InputManager to restart the interactions
    public void UntouchMediumBoiler()
    {
        isTouchMediumBoiler = false;
    }


    //Methods called by the animator controller

    public void PlayOilStream()//to add in the animator controller as a parameter
    {
        spill.PlayOilStream();
    }

    //Methods called by the animator controller

    public void StopOilStream()
    {
        spill.StopOilStream();
    }


    public void OilDissapear()
    {
        animatorOilLayer.SetTrigger("Dissapear");
    }


    public void FillBigBoiler()
    {
        animatorBigBoiler.SetTrigger("Fill");
    }
    //Methods called by the animator controller

    public void PlaySoundMediumBoilerStream()//TODO check if this has to be here

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
