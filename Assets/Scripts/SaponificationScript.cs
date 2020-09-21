using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaponificationScript : MonoBehaviour
{
    //public TextMesh resultTextMesh;
    public Text resultText;

    public GameObject resulttextObject;
    public GameObject TAG, DAG, monolein, linoleic, oleic, glycerol, OH, linoleic2;
    public SoapCreator soapBarScript;
    public AddVolume addVolumeCylinder, addVolumeBeaker;
    public GameObject cylinder, beaker;
    public SliderManager sliderManagerLye, sliderManagerOil;
    public ChatTrigger tagChat, dagChat, monoleinChat, oleicChat, glycerolChat, ohChat, linoleic2Chat;
    public ExperimentsTable experimentsTableScript;


    //float addedVolume;

    //saponification values of oils
    public float sunflowerSV = 0.191f;
    //public float coconutSV = 0.269f;
    //public float castorSV = 0.181f;

    //density of KOH at 50% and 25C
    public float densityLye = 1.51f;

 
    public static float amountLyeUsed;
    public static float amountOil;
    public float amountLyeNeeded;
    public static float amountSoap;
    public float result;

    private Vector3 tagOriginalScale, dagOriginalScale, monoleinOriginalScale, linoleicOriginalScale, oleicOriginalScale, glycerolOriginalScale, ohOriginalScale, linoleic2OriginalScale;
    float sizeMolecule = 0.03f;

    private void Start()
    {

        //Find the text in the world
        resulttextObject = GameObject.Find("Result");

        //Calling the text component
        resultText = resulttextObject.GetComponentInChildren<Text>();

        //Saving the original scale of the molecules to reset the size after visualization
        tagOriginalScale = TAG.transform.localScale;
        dagOriginalScale = DAG.transform.localScale;
        monoleinOriginalScale = monolein.transform.localScale;
        linoleicOriginalScale= linoleic.transform.localScale;
        linoleic2OriginalScale = linoleic2.transform.localScale;
        oleicOriginalScale=oleic.transform.localScale;
        glycerolOriginalScale=glycerol.transform.localScale;
        ohOriginalScale=OH.transform.localScale;

        //Chat from each molecule
        //TODO add chat trigger to each gameobject
        tagChat = TAG.GetComponent<ChatTrigger>();



    }
 
    public (float, float, float) CalculatingSoap()//Function that returns different values
    {
        addVolumeCylinder = cylinder.GetComponent<AddVolume>();
        addVolumeBeaker = beaker.GetComponent<AddVolume>();
  
        //Evaluate the variables inside to be able to change according to slider which is updated every frame
        amountLyeUsed = addVolumeCylinder.addedVolume;
        
        //print("this is lye"+ addVolumeCylinder.addedVolume);

        amountOil = addVolumeBeaker.addedVolume;
        //print("this is oil" + addVolumeBeaker.addedVolume);

        amountLyeNeeded = sunflowerSV * amountOil;
       

        //print("this is lye needed" + amountLyeNeeded);

        amountSoap = amountLyeUsed * 100 / amountLyeNeeded;

        //print("calculating soap" + amountSoap);
        AnalyzeResult(amountSoap);

        return (amountSoap, amountLyeUsed, amountOil);
    }

    private float AnalyzeResult(float amountSoap)
    {
        //print("analyze soap" + amountSoap);
        //Stoichoimetry cases

        //No Soap
        if (amountSoap == 0)
        {
            //To activate/desactivate the gameobject
            resultText.text = "This is the main triacylglyceride of sunflower oil";
            tagChat.TriggerChat();
            TAG.SetActive(true);
            TAG.transform.localScale = Vector3.one * sizeMolecule;//To scale all the components equally   
            DAG.SetActive(false);
            monolein.SetActive(false);
            linoleic.SetActive(false);
            linoleic2.SetActive(false);//TODO find a better way to duplicate the same molecule
            oleic.SetActive(false);
            glycerol.SetActive(false);
            OH.SetActive(false);
            
        }

        if (amountLyeNeeded > amountLyeUsed)

        {
            //Create SoapBottle
            soapBarScript.CreateSoap();
            resultText.text = "you converted" + "  " + amountSoap.ToString("F1") + " " + "% of the oil" + "\r\n" + "  " + "look at the molecules present in your soap!";

            //Less than 30% soap
            if (amountSoap >0&& amountSoap<30)

                {

                //Show DAG + linoleic chain
                TAG.SetActive(false);

                DAG.SetActive(true);
                DAG.transform.localScale= Vector3.one * sizeMolecule;//To scale all the components equally

                monolein.SetActive(false);


                linoleic.SetActive(true);
                linoleic.transform.localScale= Vector3.one * sizeMolecule;//To scale all the components equally

                linoleic2.SetActive(false);
                oleic.SetActive(false);
                glycerol.SetActive(false);
                OH.SetActive(false);

                print("only one chain has fallen");

                }

            //Between 30 and 70% soap
            if(amountSoap>30 && amountSoap < 90)

                {

                //Show monoleic, two linoleic chains
                print("two chains are gone");
                TAG.SetActive(false);
                DAG.SetActive(false);

                monolein.SetActive(true);
                monolein.transform.localScale = Vector3.one * sizeMolecule;

                linoleic.SetActive(true);
                linoleic.transform.localScale = Vector3.one * sizeMolecule;

                linoleic2.SetActive(true);
                linoleic2.transform.localScale = Vector3.one * sizeMolecule;

                oleic.SetActive(false);
                glycerol.SetActive(false);
                OH.SetActive(false);

                }

        }

        //Exact stoichoimetry
        if (amountLyeUsed == amountLyeNeeded && amountLyeUsed!=0)

        {
            //Create SoapBottle
            soapBarScript.CreateSoap();

            resultText.text = "your soap looks great!";
            //Show the molecules separated 2 linoleic, 1 oleic, glycerol

            TAG.SetActive(false);
            DAG.SetActive(false);

            monolein.SetActive(false);

            linoleic.SetActive(true);
            linoleic.transform.localScale = Vector3.one * sizeMolecule;

            linoleic2.SetActive(true);
            linoleic2.transform.localScale = Vector3.one * sizeMolecule;

            oleic.SetActive(true);
            oleic.transform.localScale = Vector3.one * sizeMolecule;

            

            glycerol.SetActive(true);
            glycerol.transform.localScale = Vector3.one * sizeMolecule*0.5f;

            OH.SetActive(true);
            OH.transform.localScale = Vector3.one * sizeMolecule;
            

        }

        //More Lye than needed
        if (amountLyeNeeded < amountLyeUsed)

        {
            //Create SoapBottle
            soapBarScript.CreateSoap();

            resultText.text = "your soap is ok, but be careful it can be corrosive";
            //Show the molecules separated
            //Show the molecules separated 2 linoleic, 1 oleic, glycerol and a lot of OH

            TAG.SetActive(false);
            DAG.SetActive(false);

            monolein.SetActive(false);

            linoleic.SetActive(true);
            linoleic.transform.localScale = Vector3.one * sizeMolecule;

            linoleic2.SetActive(true);
            linoleic2.transform.localScale = Vector3.one * sizeMolecule;

            oleic.SetActive(true);
            oleic.transform.localScale = Vector3.one * sizeMolecule;

            glycerol.SetActive(true);
            glycerol.transform.localScale = Vector3.one * sizeMolecule;

            OH.SetActive(true);
            OH.transform.localScale = Vector3.one * sizeMolecule;

            Instantiate(OH, OH.transform.position, OH.transform.rotation);

        }


        //Reset the values from slider to try again this reset the transform of the glass

        Invoke("CleanSlider", 2.0f);
        Invoke("ResetMolecules", 10.0f);
        Invoke("CleanResult", 10.0f);

        return result;
    }

    public void CleanSlider()
    {
        sliderManagerLye.ResetValue();
        sliderManagerOil.ResetValue();
        print("cleaning slider");        

    }

    //Reset the scale of the molecules
    public void ResetMolecules()
    {
       TAG.transform.localScale = tagOriginalScale;
       DAG.transform.localScale = dagOriginalScale =
       monolein.transform.localScale = monoleinOriginalScale;
       linoleic.transform.localScale = linoleicOriginalScale;
       linoleic2.transform.localScale = linoleic2OriginalScale;
       oleic.transform.localScale = oleicOriginalScale;
       glycerol.transform.localScale = glycerolOriginalScale;
       OH.transform.localScale = ohOriginalScale;
       TAG.SetActive(false);
       DAG.SetActive(false);
       monolein.SetActive(false);
       linoleic.SetActive(false);
       linoleic2.SetActive(false);
       oleic.SetActive(false);
       glycerol.SetActive(false);
       OH.SetActive(false);
       print("cleaning molecules");

    }

    //Clean text result
    public void CleanResult()
    {
        resultText.text = "   ";
        print("cleaning result");
    }

    //experimentsTableScript.CreateExperimentEntryTransform();

    //    private class ExperimentEntry
    //{
    //    public float oil;
    //    public float lye;
    //    public float result;

    //}

}



//addedVolume = GetComponent<SliderManager>();
//sliderManager = FindObjectOfType<SliderManager>();

//addVolumeScript = GetComponent<AddVolume>();

//amountLyeUsed = sliderManager.addedVolume;

//amountLyeUsed = addVolumeCylinder.addedVolume;//to multiply the factor of the slider for "real" volume


////amountLyeUsed = addVolumeScript.addedVolume;
//amountLyeNeeded = sunflowerSV * amountOil;
//amountSoap = amountLyeUsed * 100 / amountLyeNeeded;