﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManagerLab : MonoBehaviour
{
    public GameObject beaker, cylinder, balance, sliderLye, sliderOil, glassRod;

    Slider sliderScriptLye, sliderScriptOil;

    //public TeapotScript teapotScript;
    //public LadleScript ladleScript;
    //public WoodSaucer woodSaucerScript;
    //public SoapCreator soapBarScript;
    public Transform tableTransform;
    //public PanelManagerScript panelManagerScript;
    //public ChatManager chatManagerScript;

    Vector3 gravityVector;

    public ChatTrigger beakerChat, cylinderChat, balanceChat;
    
    public UnityEvent OnClick = new UnityEvent();

    public SaponificationScript saponificationScript;


    //// Start is called before the first frame update
    void Start()

    {
        //TODO change to beaker
        //teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        //teapotScript = teapot.GetComponent<TeapotScript>();
        beakerChat = beaker.GetComponent<ChatTrigger>();

        //sliderLye = GameObject.Find("Parent_Slider Lye");
        

        sliderScriptLye = sliderLye.GetComponentInChildren<Slider>();

        sliderScriptOil = sliderOil.GetComponentInChildren<Slider>();

        sliderLye.SetActive(false);
        sliderOil.SetActive(false);

        //woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        //woodSaucerScript = woodsaucer.GetComponent<WoodSaucer>();
        //woodSaucerChat = woodsaucer.GetComponent<ChatTrigger>();


        //ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        //ladleScript = ladle.GetComponent<LadleScript>();
        //ladleChat = ladle.GetComponent<ChatTrigger>();


        saponificationScript = beaker.GetComponent<SaponificationScript>();

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        //startingChatTrigger.TriggerChat();


        gravityVector = tableTransform.localToWorldMatrix * (new Vector3(0f, -1f, 0f));


        Physics.gravity = gravityVector.normalized * 9.81f;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            //if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot && !teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == beaker)
            {
                beakerChat.TriggerChat();
                print("beaker is touched");
                sliderOil.SetActive(true);


            }



            //if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == woodsaucer && teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == cylinder)
            {
                //sliderOil.SetActive(false);
                print("cylinder is touched");
                sliderLye.SetActive(true);
                
               
            }

            //if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == ladle && teapotScript.isTouchTeapot && woodSaucerScript.isTouchWoodsaucer)

            //{

            //}

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == glassRod)
            {
                //sliderOil.SetActive(false);
                print("time to mix");
                sliderLye.SetActive(false);

                //Hinder the interaction with the slider
                sliderScriptLye.enabled = false;
                sliderScriptOil.enabled = false;

                sliderOil.SetActive(false);
                saponificationScript.PercentageSaponification();



            }




        }

    }




}
