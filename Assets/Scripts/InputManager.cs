﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{

    public GameObject ladle, teapot, woodsaucer;
    public TeapotScript teapotScript;
    public LadleScript ladleScript;
    public WoodSaucer woodSaucerScript;
    public UnityEvent OnClick = new UnityEvent();
    private int count = 0;
    public Text countText;



    //// Start is called before the first frame update
    void Start()

    {
        teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        teapotScript=teapot.GetComponent<TeapotScript>();

        woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        woodSaucerScript = woodsaucer.GetComponent<WoodSaucer>();

        ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        ladleScript = ladle.GetComponent<LadleScript>();


    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot && !teapotScript.isTouchTeapot  && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                Debug.Log("ya vamos activando la fiesta");
                //serveWater.enabled = true;
                teapotScript.ServeWaterTeapot();
                count += 1;
                SetCountText();

            }

            else
            {
                count -= 1;
                SetCountText();
            }

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == woodsaucer && teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                Debug.Log("ya vamos echando el agua");
                woodSaucerScript.ServeWaterWoodSaucer();
                count += 1;
                //SetCountText();
            }


            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == ladle && teapotScript.isTouchTeapot && woodSaucerScript.isTouchWoodsaucer)
            {
                Debug.Log("ya vamos meneando el mengurje");
                ladleScript.MoveLadle();
                count += 1;
                //SetCountText();

            }


        }

    }

    void SetCountText()
    {
        countText.text = "Start with the teapot";
    }

}
