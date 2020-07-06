using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cylinderScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;

    public GameObject lyeLayer;

    Animator animatorCylinder, animatorlyeLayer;
    AudioSource audioSource;

    float cylinderClipLength;


    // Start is called before the first frame update
    void Start()
    {


       lyeLayer = GameObject.Find("LyeLayer");

        //getting the animator attached to the lye layer that appears on the top of the oil

        animatorlyeLayer = lyeLayer.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        //getting the animator of attached to the teapot
        animatorCylinder= gameObject.GetComponent<Animator>();


        //Fetch the current Animation clip information for the base layer
        //AnimatorClipInfo[] animatorClipInfo= this.animator.GetCurrentAnimatorClipInfo(0);
        AnimationClip[] clipsTeapot = animatorCylinder.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsTeapot)

        {
            cylinderClipLength= clip.length;
        }



    }


    //Methods called by the animator controller

    public void PlayWaterStream()//to add in the animator controller as a parameter
    {
        spill.PlayStreamContainer();
    }

    //Methods called by the animator controller

    public void StopWaterStream()
    {
        spill.StopStreamContainer();
    }

    //Methods called by the animator controller

    public void PlaySoundCylinderStream()//TODO check if this has to be here

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
