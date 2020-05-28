using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class LadleScript : MonoBehaviour
{
    [SerializeField] SmokeScriptBoiler smoke;
    public GameObject  parentLadle;
    public UnityEvent OnClick = new UnityEvent();
    Animator animatorLadle;
    ScoreBoard scoreBoard;
    Vector3 position;
    public bool isTouchLadle = false;
   

    //// Start is called before the first frame update
    void Start()


    {
        //definedButton = this.gameObject;
        parentLadle = GameObject.Find("Parent_Ladle");//Find the object with this name in the world
        animatorLadle = parentLadle.GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        //position = definedButton.transform.localPosition;
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

    // Update is called once per frame
    /*void Update()
    {
        Debug.Log("vengase la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                animatorLadle.SetTrigger("Mix");//inside the animator controller
                //PlaySound();
                scoreBoard.ScoreSoap();//to increase the scoreboard
            }
        }

    }
    */



    // private void PlaySound()
    //{
    //    if (!audioSource.isPlaying)                    //if the audio is not playing

    //    {
    //        audioSource.Play();
    //    }

    //    else

    //    {
    //        audioSource.Stop();
    //    }
    //}
}
  



