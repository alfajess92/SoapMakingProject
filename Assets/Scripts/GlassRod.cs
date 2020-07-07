using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRod : MonoBehaviour
{

 
    /// This script is similar to LadleScript
   
    public GameObject parentGlassRod;
    Animator animatorGlassRod;
    public bool isTouchGlassRod = false;
    public float glassRodClipLength;
  


    // Start is called before the first frame update
    void Start()
    {
        parentGlassRod = GameObject.Find("Parent_GlassRod");//Find the object with this name in the world

        animatorGlassRod = parentGlassRod.GetComponent<Animator>();

        //Fetch the current Animation clip information for the base layer
        AnimationClip[] clipsGlassRod = animatorGlassRod.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsGlassRod)

        {
            glassRodClipLength = clip.length;
        }


    }


    public void MoveGlassRod()
    {
        animatorGlassRod.SetTrigger("Mix");//inside the animator controller
        Invoke ("TouchGlassRod", glassRodClipLength);

    }


    public void TouchGlassRod()
    {
        isTouchGlassRod = true;
    }

    public void UnTouchGlassRod()
    {
        isTouchGlassRod = false;
    }

}
