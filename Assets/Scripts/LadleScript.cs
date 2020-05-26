using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class LadleScript : MonoBehaviour
{
    public GameObject definedButton, ladle;
    public UnityEvent OnClick = new UnityEvent();
    Animator animatorLadle;
    AudioSource audioSource;
    ScoreBoard scoreBoard;
    Vector3 position;
    //public AudioClip sound;

    //// Start is called before the first frame update
    void Start()


    {
        definedButton = this.gameObject;
        ladle = GameObject.Find("Parent_Ladle");//Find the object with this name in the world
        animatorLadle = ladle.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        position = definedButton.transform.localPosition;
        scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world
          //animator = GetComponentInParent<Animator>();
        ////animator = GetComponentInChildren<Animator>();

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
                animatorLadle.SetTrigger("Mix");//inside the animator controller
                //PlaySound();
                scoreBoard.ScoreSoap();//to increase the scoreboard
            }
        }

    }

 public void PlaySound()
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
  



