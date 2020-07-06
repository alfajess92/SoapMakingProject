using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    public GameObject ladle, teapot, woodsaucer, soapBar, table, mediumBoiler;
        
    public TeapotScript teapotScript;
    public LadleScript ladleScript;
    public WoodSaucer woodSaucerScript;
    public SoapCreator soapBarScript;
    public MediumBoilerScript mediumBoilerScript;
    public Transform tableTransform;
    public PanelManagerScript panelManagerScript;
    public ChatManager chatManagerScript;

    Vector3 gravityVector;

    public ChatTrigger teapotChat, ladleChat, woodSaucerChat, mediumBoilerChat;
    //public ChatTrigger chat;
    public UnityEvent OnClick = new UnityEvent();


    //// Start is called before the first frame update
    void Start()

    {
        mediumBoilerScript = mediumBoiler.GetComponent<MediumBoilerScript>();
        mediumBoilerChat = mediumBoiler.GetComponent<ChatTrigger>();
 
        //teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        teapotScript = teapot.GetComponent<TeapotScript>();
        teapotChat = teapot.GetComponent<ChatTrigger>();

        //woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        woodSaucerScript = woodsaucer.GetComponent<WoodSaucer>();
        woodSaucerChat = woodsaucer.GetComponent<ChatTrigger>();

        //table = GameObject.Find("Table");
        //tableTransform = table.transform;

        //ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        ladleScript = ladle.GetComponent<LadleScript>();
        ladleChat = ladle.GetComponent<ChatTrigger>();

        //startingChat = GameObject.Find("StartingChat");
        //startingChatTrigger = startingChat.GetComponent<ChatTrigger>();

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;
        //startingChatTrigger.TriggerChat();


        gravityVector = tableTransform.localToWorldMatrix * (new Vector3(0f, -1f, 0f));
        //tablePosition = new Vector3(tableTransform.localPosition.x, tableTransform.localPosition.y, tableTransform.localPosition.z);

        Physics.gravity = gravityVector.normalized*9.81f; 
        
        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == mediumBoiler && !mediumBoilerScript.isTouchMediumBoiler && !teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                mediumBoilerChat.TriggerChat();
                mediumBoilerScript.ServeOilBoiler();
               
            }

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot && mediumBoilerScript.isTouchMediumBoiler && !teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                teapotChat.TriggerChat();
                teapotScript.ServeWaterTeapot();
                //soapBarScript.CreateSoap();
            }


            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == woodsaucer && mediumBoilerScript.isTouchMediumBoiler && teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                woodSaucerChat.TriggerChat();
                woodSaucerScript.ServeWaterWoodSaucer();

            }

            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == ladle && mediumBoilerScript.isTouchMediumBoiler && teapotScript.isTouchTeapot && woodSaucerScript.isTouchWoodsaucer)

                
            {
                print("touchladle");
                ladleScript.MoveLadle();
                ladleChat.TriggerChat();

                //TODO only create soap after X amount of mixing
                soapBarScript.CreateSoap();

            }



        }



    }


    public void ResetTouch()
    {
        print("reset everything");
        panelManagerScript.ExitNextScenePanel();
        teapotScript.UntouchTeapot();
        woodSaucerScript.UntouchWoodSaucer();
        ladleScript.UntouchLadle();
        //soapBarScript.DestroySoap();

    }



}