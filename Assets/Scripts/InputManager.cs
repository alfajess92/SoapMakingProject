using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{

    public GameObject ladle, teapot, woodsaucer;
    public TeapotScript teapotScript;
    public LadleScript ladleScript;
    public WoodSaucer woodSaucerScript;

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

        ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world TODO check if GameObject.Find is the best approach
        ladleScript = ladle.GetComponent<LadleScript>();
        ladleChat = ladle.GetComponent<ChatTrigger>();
        //chat = FindObjectOfType<ChatTrigger>();

    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot && !teapotScript.isTouchTeapot && !woodSaucerScript.isTouchWoodsaucer && !ladleScript.isTouchLadle)
            {
                teapotChat.TriggerChat();
                Debug.Log("ya vamos activando la fiesta");
                teapotScript.ServeWaterTeapot();

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
 
                ladleScript.MoveLadle();
                ladleChat.TriggerChat();
                Invoke("ResetTouch", 5f);

            }



        }






    }


    public void ResetTouch()
    {
        teapotScript.UntouchTeapot();
        woodSaucerScript.UntouchWoodSaucer();
        ladleScript.UntouchLadle();
    }
    
}