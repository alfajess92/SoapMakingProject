using System.Collections;
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

    public SaponificationScript saponificationScript;
    public GlassRod glassRodScript;
    public Transform tableTransform;
    //public PanelManagerScript panelManagerScript;
    //public ChatManager chatManagerScript;

    Vector3 gravityVector;

    public ChatTrigger beakerChat, cylinderChat, balanceChat, glassRodChat;
    public UnityEvent OnClick = new UnityEvent();


    //// Start is called before the first frame update
    void Start()

    {
        //beaker
        beakerChat = beaker.GetComponent<ChatTrigger>();

        //sliders
        sliderScriptLye = sliderLye.GetComponentInChildren<Slider>();
        sliderScriptOil = sliderOil.GetComponentInChildren<Slider>();
        sliderLye.SetActive(false);
        sliderOil.SetActive(false);

        //glassrod
        glassRodChat = glassRod.GetComponent<ChatTrigger>();
        saponificationScript = glassRod.GetComponent<SaponificationScript>();
        glassRodScript = glassRod.GetComponent<GlassRod>();
    }


    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        //To fix the gravity of the world with the image target
        gravityVector = tableTransform.localToWorldMatrix * (new Vector3(0f, -1f, 0f));
        Physics.gravity = gravityVector.normalized * 9.81f;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {

            //Touching the beaker
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == beaker)
            {
                beakerChat.TriggerChat();
                print("beaker is touched");
                sliderOil.SetActive(true);
            }

            //Choosing the lye and oil
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == cylinder)
            {
                cylinderChat.TriggerChat();
                print("cylinder is touched");
                sliderLye.SetActive(true);
            }



            //Glassrod and calcute soap
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == glassRod)
            {
                glassRodChat.TriggerChat();
                //print("glassrod is touched");

                //To desactivate the gameobject 
                sliderLye.SetActive(false);
                sliderOil.SetActive(false);


                //Hinder the interaction with the slider script
                sliderScriptLye.enabled = false;
                sliderScriptOil.enabled = false;
                

                saponificationScript.CalculatingSoap();
                glassRodScript.MoveGlassRod();
               

            }




        }

    }




}
