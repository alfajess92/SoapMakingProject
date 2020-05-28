using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class TeapotScript : MonoBehaviour
{
    public GameObject  waterAsh;
    Animator animator, animatorWaterAsh;
    public bool isTouchTeapot = false;

    //// Start is called before the first frame update
    void Start()


    {
        //definedButton = this.gameObject;
        waterAsh = GameObject.Find("WaterProDaytime");
        animator = GetComponent<Animator>();
        animatorWaterAsh = waterAsh.GetComponent<Animator>();
        //position = definedButton.transform.localPosition;
    }

 
    public void ServingWater()
    {
        animator.SetTrigger("Serve");//inside the animator controller
        animatorWaterAsh.SetTrigger("Fill");
        isTouchTeapot = true;
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
