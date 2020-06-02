using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vuforia;

public class LadleScript : MonoBehaviour
{
    [SerializeField] SmokeScriptBoiler smoke;
    public GameObject  parentLadle;
    
    Animator animatorLadle;
    ScoreBoard scoreBoard;

    public bool isTouchLadle = false;
   float 

    //// Start is called before the first frame update
    void Start()


    {

        parentLadle = GameObject.Find("Parent_Ladle");//Find the object with this name in the world
        animatorLadle = parentLadle.GetComponent<Animator>();
        scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world


        AnimationClip[] clipsLadle = animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsLadle)

        {
           ladleClipLength = clip.length;
        }

    }



   public  void MoveLadle()
    {
        animatorLadle.SetTrigger("Mix");//inside the animator controller
        StartSmoke();
        scoreBoard.ScoreSoap();
        //isTouchLadle = true;

        Invoke("TouchLadle", ladleClipLength);//
    }


    public void TouchLadle()
    {
        isTouchLadle = true;
    }


    //Called from InputManager to restart the interactions
    public void UntouchLadle()
    {
        isTouchLadle = false;
    }



    //Methods called by the animator controller

    public void StartSmoke()
    {
        smoke.PlaySmokeBoiler();
    }


    //Methods called by the animator controller

    public void StopSmoke()
    {
       smoke.StopSmokeBoiler();
    }

    
}
  



