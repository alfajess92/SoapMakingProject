using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TeapotScript : MonoBehaviour
{
    [SerializeField] SpillScript spill;

    public GameObject  waterAsh;
    Animator animator, animatorWaterAsh;
    AudioSource audioSource;
    //ParticleSystem waterStreamTeapot;
    public bool isTouchTeapot = false;

    //// Start is called before the first frame update
    void Start()


    {
        waterAsh = GameObject.Find("WaterProDaytime");
        animator = GetComponent<Animator>();
        animatorWaterAsh = waterAsh.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //waterStreamTeapot = GetComponent<ParticleSystem>();
    }

 
    public void ServeWaterTeapot()
    {
        animator.SetTrigger("Serve");//inside the animator controller
        animatorWaterAsh.SetTrigger("Fill");
        isTouchTeapot = true;
    }

    public void PlayWaterStream()//to add in the animator controller as a parameter
    {
        spill.PlayWaterStreamTeapot();
    }

    public void StopWaterStream()
    {
        spill.StopWaterStreamTeapot();
    }



    public void PlaySoundTeapotStream()//TODO check if this has to be here

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

    // Update is called once per frame
    /*void Update()
    {
        Debug.Log("vengase la teapot");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                animator.SetTrigger("Serve");//inside the animator controller
                animatorWaterAsh.SetTrigger("Fill");
            }

        }

    }
    */

}
