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
   

    //// Start is called before the first frame update
    void Start()


    {

        parentLadle = GameObject.Find("Parent_Ladle");//Find the object with this name in the world
        animatorLadle = parentLadle.GetComponent<Animator>();
        scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world
       
    }



   public  void MoveLadle()
    {
        animatorLadle.SetTrigger("Mix");//inside the animator controller
        StartSmoke();
        scoreBoard.ScoreSoap();
        isTouchLadle = true; 
    }

    public void StartSmoke()
    {
        smoke.PlaySmokeBoiler();
    }

    public void StopSmoke()
    {
       smoke.StopSmokeBoiler();
    }

    
}
  



