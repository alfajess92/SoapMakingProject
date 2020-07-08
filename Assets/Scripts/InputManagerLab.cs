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
    //public SoapCreator soapBarScript;
    public ShowVolumeScript showVolumeScriptLye, ShowVolumeScriptBalance;
    


    public Transform tableTransform;
    //public PanelManagerScript panelManagerScript;
    //public ChatManager chatManagerScript;

    Vector3 gravityVector;

    public ChatTrigger beakerChat, cylinderChat, balanceChat, glassRodChat;
    public UnityEvent OnClick = new UnityEvent();

    public CylinderScript cylinderScript;

    int counter = 0;

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



        //cylinder
        cylinderScript = cylinder.GetComponent < CylinderScript>();
        cylinderChat = cylinder.GetComponent<ChatTrigger>();
    }


    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        //To fix the gravity of the world with the image target
        gravityVector = tableTransform.localToWorldMatrix * (new Vector3(0f, 1f, 0f));
        Physics.gravity = gravityVector.normalized * 9.81f;

        //if (Input.touchCount>0 && Input.touches[0].phase==TouchPhase.Began)
        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            //Touching the beaker
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == beaker && !cylinderScript.isTouchCylinder&& !glassRodScript.isTouchGlassRod)
            {
                beakerChat.TriggerChat();
                sliderOil.SetActive(true);
                sliderLye.SetActive(true);
            }

            //Choosing the lye and oil
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == cylinder&& !glassRodScript.isTouchGlassRod)
            {
                cylinderChat.TriggerChat();

                //To desactivate the gameobject 
                sliderLye.SetActive(false);
                sliderOil.SetActive(false);

                cylinderScript.ServeLye();//trigger the animation from script

                ////Hinder the interaction with the slider script
                //sliderScriptLye.enabled = false;
                //sliderScriptOil.enabled = false;

            }

            //Glassrod and calcute soap
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == glassRod && cylinderScript.isTouchCylinder)
            {
                glassRodChat.TriggerChat();
                glassRodScript.MoveGlassRod();
                //Calculate soap after the glassrod finish the animation
                Invoke("CalculatingSoap", glassRodScript.glassRodClipLength);

            }

            // TODO HideMolecules

            //Reseting parameters
            //Create a bottle of soap
            //Reset the values from slider
            Invoke("ResetTouchLab", 1.0f);
            counter++;

        }

    }

    public void ResetTouchLab()

    {
        glassRodScript.UnTouchGlassRod();
        cylinderScript.UnTouchCylinder();
        print("reset touch");
        showVolumeScriptLye.DeleteText();
        print("text deleted");
        ShowVolumeScriptBalance.DeleteText();

    }


    public void CalculatingSoap()
    {
   
        saponificationScript.CalculatingSoap();
        //soapBarScript.CreateSoap();
    }
}
