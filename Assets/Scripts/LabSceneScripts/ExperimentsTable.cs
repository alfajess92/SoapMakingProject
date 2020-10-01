using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperimentsTable : MonoBehaviour
{
    public Transform entryContainer;
    public  Transform entryTemplate;
    public  List<ExperimentEntry> experimentEntriesList;
    public  List<Transform> entryTransformList;
    //private Experiments experiments;

    //private void Awake()
    //{
        
    //    entryContainer = GameObject.Find("EntryContainer").transform;
    //    entryTemplate = GameObject.Find("EntryTemplate").transform;
    //    entryTemplate.gameObject.SetActive(false);

    //    experimentEntriesList = new List<ExperimentEntry>()
    //        {
    //        new ExperimentEntry { lye=0f, oil=0f, result=100000 },
    //        new ExperimentEntry { lye=150f, oil=20f, result=200 },
    //        new ExperimentEntry { lye=20f, oil=5f, result=5000 },
    //        };


    //    entryTransformList = new List<Transform>();//create the empty list for transform

    //    foreach (ExperimentEntry experimentEntry in experimentEntriesList)//cycle to the list
    //    {
    //        CreateExperimentEntryTransform(experimentEntry, entryContainer, entryTransformList);
    //    }

    //}


    public void CreateExperimentEntryTransform(ExperimentEntry experimentEntry, Transform container, List<Transform> transformList)
    {
        print("this is container"+container);
        print("this is the entryTemplate"+entryTemplate);
        float templateHeight = 20f;
        Transform entryTransform = Instantiate(entryTemplate, container);//instatiate empty transform
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();//to grab reference
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;//to assign experiment number, given by the position on the list
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "th"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;

        }

        entryTransform.Find("experiment").GetComponent<Text>().text = rankString;

        //amount of oil
        float oil = experimentEntry.oil;// read volume from slider/saponification script
        entryTransform.Find("Oil").GetComponent<Text>().text = oil.ToString("F1") + " " + "g ";


        //amount of lye
        float lye = experimentEntry.lye;
        entryTransform.Find("Lye").GetComponent<Text>().text = lye.ToString("F1")+ " " + "g ";

        //Result or amount of soap
        float result = experimentEntry.result;// from Saponification Script, result text
        float x;
        if (result >=100)
        {
            x = 100f;
        }
        else 
        {
            x = experimentEntry.result;
        }

        entryTransform.Find("Result").GetComponent<Text>().text = x.ToString("F1") + " " + "% ";

        //Excess of lye used

        float excess = experimentEntry.excess; // from Saponification Script, result text
        float y;
        if (excess<0)//
        {
            y = experimentEntry.excess;
        }
        else 
        {
            y = 0f;
        }


        entryTransform.Find("ExcessLye").GetComponent<Text>().text = y.ToString("F1") + " " + "g ";

        transformList.Add(entryTransform);
    }


    //TODO read the values from the other scripts (saponification, AddVolume)

    public  class ExperimentEntry
    {
        public float oil;
        public float lye;
        public float result;
        public float excess;

    }

    private class Experiments//object that contains the list of experiments
    {
        public List<ExperimentEntry> experimentEntriesList;

    }
}
