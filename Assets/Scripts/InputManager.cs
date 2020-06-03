﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    public GameObject ladle, teapot, woodsaucer, soapBar, table;
    public TeapotScript teapotScript;
    public LadleScript ladleScript;
    public WoodSaucer woodSaucerScript;
    public SoapCreator soapBarScript;
    public Transform tableTransform;

    Vector3 gravityVector;

    public ChatTrigger teapotChat, ladleChat, woodSaucerChat;
    public ChatTrigger chat;
    public UnityEvent OnClick = new UnityEvent();


    //// Start is called before the first frame update
    void Start()

    {
        teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        teapotScript = teapot.GetComponent<TeapotScript>();
        teapotChat = teapot.GetComponent<ChatTrigger>();

        woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        woodSaucerScript = woodsaucer.GetComponent<WoodSaucer>();
        woodSaucerChat = woodsaucer.GetComponent<ChatTrigger>();

        //table = GameObject.Find("Table");
        //tableTransform = table.transform;

        ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        ladleScript = ladle.GetComponent<LadleScript>();
        ladleChat = ladle.GetComponent<ChatTrigger>();
        //chat = FindObjectOfType<ChatTrigger>();

        //soapBar = GameObject.Find("SoapBar");
        

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;


        
        gravityVector = tableTransform.localToWorldMatrix * (new Vector3(0f, -1f, 0f));
        //tablePosition = new Vector3(tableTransform.localPosition.x, tableTransform.localPosition.y, tableTransform.localPosition.z);

        Physics.gravity = gravityVector.normalized*9.81f; 
        
        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot && !teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                teapotChat.TriggerChat();
                Debug.Log("ya vamos activando la fiesta");
                
                teapotScript.ServeWaterTeapot();
                soapBarScript.CreateSoap();

            }



            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == woodsaucer && teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                woodSaucerChat.TriggerChat();

                Debug.Log("ya vamos echando el agua");
                woodSaucerScript.ServeWaterWoodSaucer();
                //Debug.Log("woodsaucer speaking");


            }

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == ladle && teapotScript.isTouchTeapot && woodSaucerScript.isTouchWoodsaucer)

            {
                print("touchladle");
                ladleScript.MoveLadle();
                ladleChat.TriggerChat();
                soapBarScript.CreateSoap();
                //soapBarScript.Destruction();
                //Invoke ("ResetTouch", 1f);

            }



        }






    }


    public void ResetTouch()
    {
        print("reset everything");
        teapotScript.UntouchTeapot();
        woodSaucerScript.UntouchWoodSaucer();
        ladleScript.UntouchLadle();
        print(teapotScript.isTouchTeapot);
        print(woodSaucerScript.isTouchWoodsaucer);
        print(ladleScript.isTouchLadle);
    }


    
}