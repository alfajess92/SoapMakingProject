using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaponificationScript : MonoBehaviour
{
    //public TextMesh resultTextMesh;
    public Text resultText;

    public GameObject resulttextObject;


    public AddVolume addVolumeCylinder, addVolumeBeaker;

    public GameObject cylinder, beaker;
    public SliderManager sliderManager;

    float addedVolume;


    //saponification values of oils
    public float sunflowerSV = 0.191f;
    //public float coconutSV = 0.269f;
    //public float castorSV = 0.181f;

    //density of KOH at 50% and 25C
    public float densityLye = 1.51f;

    //public float amountSoap;
    //public float amountOil = 200f;//TODO  change it to be interactable?


    public float amountLyeUsed;
    public float amountOil;
    public float amountLyeNeeded;
    public float amountSoap;


    private void Start()
    {

        //Find the text in the world
        resulttextObject = GameObject.Find("Result");

        //Calling the text componentß
        resultText = resulttextObject.GetComponentInChildren<Text>();

        //addedVolume = GetComponent<SliderManager>();
        //sliderManager = FindObjectOfType<SliderManager>();

        //addVolumeScript = GetComponent<AddVolume>();

        //amountLyeUsed = sliderManager.addedVolume;

        //amountLyeUsed = addVolumeCylinder.addedVolume;//to multiply the factor of the slider for "real" volume


        ////amountLyeUsed = addVolumeScript.addedVolume;
        //amountLyeNeeded = sunflowerSV * amountOil;
        //amountSoap = amountLyeUsed * 100 / amountLyeNeeded;


    }
 

   public  void CalculatingSoap()
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
    }

    private void AnalyzeResult(float amountSoap)
    {
        print("analyze soap" + amountSoap);
        if (amountLyeNeeded > amountLyeUsed)

        {

            resultText.text = "you converted" + amountSoap + "% of the oil" + "," + "add more lye!";
            //resultTextMesh.text = "you need more lye, only" + amountSoap + "%" + "has been created" + "," + "add more!";
                if (amountSoap <30)

                {

                //Show DAG + linoleic chain
                    print("only one chain has fallen");

                }

                if(amountSoap>30&& amountSoap < 70)

                {

                //Show monoleil, two linoleic chains
                    print("two chains are gone");
                }


        }

        if (amountLyeUsed == amountLyeNeeded && amountLyeUsed!=0)

        {

            resultText.text = "your soap looks great!";
            //Show the molecules separated 2 linoleic, 1 oleic, glycerol
        

        }


        if (amountLyeNeeded < amountLyeUsed)

        {
            resultText.text = "your soap is ok, but be careful it can be corrosive";
            //Show the molecules separated
            //Show the molecules separated 2 linoleic, 1 oleic, glycerol and a lot of OH
        }


    }





}
