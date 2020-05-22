using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class LadleScript : MonoBehaviour
{

 


    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    Animator animator;
    AudioSource audioSource;
    ScoreBoard scoreBoard;


    //// Start is called before the first frame update
    void Start()


    {
        definedButton = this.gameObject;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world
    }



    // Update is called once per frame
    void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {

                animator.SetTrigger("Mix");//inside the animator controller
                scoreBoard.ScoreSoap();//to increase the scoreboard

                if (!audioSource.isPlaying)                    //if the audio is not playing

                {
                    audioSource.Play();
                }
                else

                {
                    audioSource.Stop();
                }
                //Debug.Log("button clicked");
                
            }


        }


    }


  

}

