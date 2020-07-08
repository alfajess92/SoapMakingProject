using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;

    public GameObject lyeLayer;

    Animator animatorCylinder, animatorlyeLayer;
    AudioSource audioSource;
    public bool isTouchCylinder = false;
    float cylinderClipLength;

    AddVolume addVolumeScript;

    // Start is called before the first frame update
    void Start()
    {
        //audio of pouring lye
        audioSource = GetComponent<AudioSource>();
        addVolumeScript = GetComponent<AddVolume>();

        //getting the animator of attached to the cylinder
        animatorCylinder= gameObject.GetComponent<Animator>();


        //Fetch the current Animation clip information for the base layer
        AnimationClip[] clipsCylinder = animatorCylinder.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsCylinder)

        {
            cylinderClipLength= clip.length;
        }
    }

    public void ServeLye()
    {
        animatorCylinder.SetTrigger("Serve");//inside the animator controller

        //Called the bool condition only when the animation is finished
        Invoke("TouchCylinder", cylinderClipLength);//
        //TODO add a lye layer inside beaker
    
    }


    //It dissapear the lye of the cylinder as a result of serving it by reading the "original" transform of the gameObject inside the AddVolumeScript
    //This method is called by the animator controller of the cylinder
    public void DissapearLye()
    {
        addVolumeScript.DeleteVolume();

    }

    public void TouchCylinder()
    {
        isTouchCylinder = true;
    }

    //Called from InputManager to restart the interactions
    public void UnTouchCylinder()
    {
        isTouchCylinder = false;
    }

    //Methods called by the animator controller
    public void PlayLiquidStream()//to add in the animator controller as a parameter
    {
        spill.PlayStreamContainer();
    }

    public void StopLiquidStream()
    {
        spill.StopStreamContainer();
    }

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
