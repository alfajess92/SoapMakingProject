using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
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

    //Elements for the ResultsTable
    public ExperimentsTable experimentTable;
    private Transform entryContainer;
    public Transform entryTemplate;
    public List<ExperimentsTable.ExperimentEntry> experimentEntriesList;
    public ExperimentsTable.ExperimentEntry experiment;
    public List<Transform> entryTransformList;


    public float oil;
    public float lye;
    public float result;
    public float excess;


    private void Awake()
    {
        entryContainer = GameObject.Find("EntryContainer").transform;
        entryTemplate = GameObject.Find("EntryTemplate").transform;
        //entryTemplate = transform.Find("EntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        experimentTable = entryContainer.GetComponent<ExperimentsTable>();

        //Creating the experiment entry object (inherited from ExperimentsTable)
        experiment = new ExperimentsTable.ExperimentEntry { lye=lye, oil=oil, result=result, excess=excess};

        entryTransformList = new List<Transform>();//create the empty list for transform

        //experimentEntriesList = new List<ExperimentsTable.ExperimentEntry>();
        //{
        //new ExperimentsTable.ExperimentEntry{ lye=0f, oil=0f, result=100000 },
        //new ExperimentsTable.ExperimentEntry{ lye=150f, oil=20f, result=200 },
        //new ExperimentsTable.ExperimentEntry { lye=20f, oil=5f, result=5000 },
        //};
        

        //foreach (ExperimentsTable.ExperimentEntry experimentEntry in experimentEntriesList)//cycle to the list
        //{
        //    experimentTable.CreateExperimentEntryTransform(experimentEntry, entryContainer, entryTransformList);
        //}

    }

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
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == beaker && !cylinderScript.isTouchCylinder && !glassRodScript.isTouchGlassRod)
                {
                    beakerChat.TriggerChat();
                    sliderOil.SetActive(true);
                    sliderLye.SetActive(true);
                }

                //Choosing the lye and oil
                if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == cylinder && !glassRodScript.isTouchGlassRod)
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
                Invoke("ResetTouchLab", 5.0f);
                //counter++;
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
        //Calculating the amount of soap 
        saponificationScript.CalculatingSoap();
        
        //Create reading the results from saponification script
        ReadExperimentResults();
        //print("this is the resultoooo from experiment" + experiment.result);

        //Creating the entry experiment
        experimentTable.CreateExperimentEntryTransform(experiment, entryContainer, entryTransformList);
        //print("this is the resultoooo from experiment" + experiment.result);
       
    }

    //Function to read the input and results from Saponification script
    public ExperimentsTable.ExperimentEntry ReadExperimentResults()
    {
        //float oil;
        oil = SaponificationScript.amountOil;
        //print("This is the oil from experiment" + oil);

        //float lye;
        lye = SaponificationScript.amountLyeUsed ;

        //float result;
        result=SaponificationScript.amountSoap;

        //float lye excess
        excess = SaponificationScript.amountLyeExcess;
        print("this is excess lye" + excess);


        experiment.lye = lye;
        experiment.oil = oil;
        experiment.result = result;
        experiment.excess = excess;

        return experiment;
    }
    
   
}
