using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaponificationScript : MonoBehaviour
{

    public AddVolume addVolumeCylinder;
    public GameObject cylinder;
    public SliderManager sliderManager;

    float addedVolume;


    //saponification values of oils
    public float sunflowerSV = 0.191f;
    public float coconutSV = 0.269f;
    public float castorSV = 0.181f;

    //density of KOH at 50% and 25C
    public float densityLye = 1.51f;

    //public float amountSoap;
    public float amountOil = 200f;//TODO  change it to be interactable?


    float amountLyeUsed;
    float amountLyeNeeded;
    //float lyeExcess;
    float amountSoap;


    private void Start()
    {

        GameObject cylinder = GameObject.Find("Cylinder");

        AddVolume addVolumeCylinder= cylinder.GetComponent<AddVolume>();


        //addedVolume = GetComponent<SliderManager>();
        //sliderManager = FindObjectOfType<SliderManager>();

        //addVolumeScript = GetComponent<AddVolume>();

        //amountLyeUsed = sliderManager.addedVolume;

        //amountLyeUsed = addVolumeCylinder.addedVolume;//to multiply the factor of the slider for "real" volume


        ////amountLyeUsed = addVolumeScript.addedVolume;
        //amountLyeNeeded = sunflowerSV * amountOil;
        //amountSoap = amountLyeUsed * 100 / amountLyeNeeded;


    }
 





   public  void PercentageSaponification()
        {

        amountLyeUsed = addVolumeCylinder.addedVolume;

        amountLyeNeeded = sunflowerSV * amountOil;
        amountSoap = amountLyeUsed * 100 / amountLyeNeeded;


        if (amountLyeNeeded > amountLyeUsed)

            {
                print("you need more lye, only" + amountSoap + "%" + "has been created");
            }

            else if (amountLyeUsed==amountLyeNeeded)

            {
                print("your soap looks great!");
            }


            else if  (amountLyeNeeded< amountLyeUsed)

            {
                 print("your soap is ok, but be careful it can be corrosive");

            }

            else
                {
                 print("retry");
                }
   
            }

   




}
