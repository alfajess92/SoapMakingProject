using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRod : MonoBehaviour
{

 
    /// This script is similar to LadleScript
   
    public GameObject parentGlassRod;

    Animator animatorGlassRod;
    //ScoreBoard scoreBoard;

    public bool isTouchGlassRod = false;
    float glassRodClipLength;
    //ChatTrigger chat;


    // Start is called before the first frame update
    void Start()
    {
        parentGlassRod = GameObject.Find("Parent_GlassRod");//Find the object with this name in the world

        animatorGlassRod = parentGlassRod.GetComponent<Animator>();
        //scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world
        //chat = GetComponent<ChatTrigger>();

        AnimationClip[] clipsGlassRod = animatorGlassRod.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsGlassRod)

        {
            glassRodClipLength = clip.length;
        }


    }


    public void MoveGlassRod()
    {
        animatorGlassRod.SetTrigger("Mix");//inside the animator controller
        //print(glassRodClipLength);
        TouchGlassRod();
    }


    public void TouchGlassRod()
    {
        isTouchGlassRod = false;
    }

}
