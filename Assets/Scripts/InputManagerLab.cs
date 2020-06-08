using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManagerLab : MonoBehaviour
{
    public GameObject beaker, burette, balance;
    //public TeapotScript teapotScript;
    //public LadleScript ladleScript;
    //public WoodSaucer woodSaucerScript;
    //public SoapCreator soapBarScript;
    public Transform tableTransform;
    //public PanelManagerScript panelManagerScript;
    //public ChatManager chatManagerScript;

    Vector3 gravityVector;

    public ChatTrigger beakerChat, buretteChat, balanceChat;
    //public ChatTrigger chat;
    public UnityEvent OnClick = new UnityEvent();


    //// Start is called before the first frame update
    void Start()

    {
        //TODO change to beaker
        //teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        //teapotScript = teapot.GetComponent<TeapotScript>();
        beakerChat = beaker.GetComponent<ChatTrigger>();

        //woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        //woodSaucerScript = woodsaucer.GetComponent<WoodSaucer>();
        //woodSaucerChat = woodsaucer.GetComponent<ChatTrigger>();


        //ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        //ladleScript = ladle.GetComponent<LadleScript>();
        //ladleChat = ladle.GetComponent<ChatTrigger>();




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
                //teapotScript.ServeWaterTeapot();
                ////soapBarScript.CreateSoap();
                print("beaker is touched");

            }



            //if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == woodsaucer && teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == burette)
            {
                //woodSaucerChat.TriggerChat();
                //woodSaucerScript.ServeWaterWoodSaucer();
                print("burette is touched");
            }

            //if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == ladle && teapotScript.isTouchTeapot && woodSaucerScript.isTouchWoodsaucer)


            //{

            //    //print("touchladle");
            //    //ladleScript.MoveLadle();
            //    //ladleChat.TriggerChat();
            //    ////TODO only create soap after X amount of mixing
            //    //soapBarScript.CreateSoap();


            //}



        }

    }




}
