using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class LadleScript : MonoBehaviour
{

    // Vector3 target = new Vector3(0.651f, -0.018f, 0.324f);

    //public GameObject ladle;

    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    Animator animator;
    AudioSource audioSource;
    //Quaternion originalRot; //variable to save the rotation of the object
    //Vector3 initialPos;
 

    //public float mixSpeed = 100f;
    //public float rotateSpeed = 100f;

    //// Start is called before the first frame update
    void Start()


    {
        definedButton = this.gameObject;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //originalRot = transform.localRotation;// to store the original rotation
        //initialPos = transform.localPosition;

    }



    // Update is called once per frame
    void Update()
    {
        //transform.Rotate(Vector3.down * Time.deltaTime * 100);///simple rotation

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {

                animator.SetTrigger("Mix");//inside the animator controller
                if (!audioSource.isPlaying)                    //if the audio is not playing

                {
                    audioSource.Play();
                }
                else

                {
                    audioSource.Stop();
                }
                Debug.Log("button clicked");

                //Invoke("ResetPosition", 5f);

                //transform.Translate(Vector3.forward * mixSpeed * Time.deltaTime);
                //transform.Translate(-Vector3.forward * mixSpeed * Time.deltaTime);

                //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
                //transform.Rotate (-Vector3.up * rotateSpeed * Time.deltaTime);
            }


        }


    }


  

}

