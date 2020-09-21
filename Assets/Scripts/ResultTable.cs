using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResultTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<ExperimentEntry> experimentEntriesList;
    private List<Transform> entryTransformList;
    //private Experiments experiments;

    //private void Awake()
    //{
    //    //entryContainer = transform.Find("EntryContainer");
    //    //entryTemplate = transform.Find("EntryTemplate");
    //    entryContainer = GameObject.Find("EntryContainer").transform;
    //    entryTemplate = GameObject.Find("EntryTemplate").transform;
    //    entryTemplate.gameObject.SetActive(false);

    //    //experimentEntriesList = new List<ExperimentEntry>()
    //    //    {
    //    //    new ExperimentEntry { lye=0f, oil=0f, result=100000 },
    //    //    new ExperimentEntry { lye=150f, oil=20f, result=200 },
    //    //    new ExperimentEntry { lye=20f, oil=5f, result=5000 },
    //    //    };

    //    //AddExperimentEntry(10000f, 1f, 1f);

    //    //string jsonString = PlayerPrefs.GetString("experimentsTable");
    //    //Experiments experiments = JsonUtility.FromJson<Experiments>(jsonString);//return the experiments objects

    //    //    //  sorting algorithm by result
    //    //    for (int i = 0; i < experiments.experimentEntriesList.Count; i++)
    //    //    {
    //    //        for (int j = i + 1; j < experiments.experimentEntriesList.Count; j++)
    //    //        {
    //    //            if (experiments.experimentEntriesList[j].result > experiments.experimentEntriesList[i].result)
    //    //            {
    //    //                //swap
    //    //                ExperimentEntry tmp = experiments.experimentEntriesList[i];
    //    //                experiments.experimentEntriesList[i] = experiments.experimentEntriesList[j];
    //    //                experiments.experimentEntriesList[j] = tmp;
    //    //            }
    //    //        }
    //    //    }

    //    entryTransformList = new List<Transform>();//create the empty list for transform

    //    //foreach (ExperimentEntry experimentEntry in experiments.experimentEntriesList)//cycle to the list
    //        foreach (ExperimentEntry experimentEntry in experimentEntriesList)//cycle to the list
    //        {
    //        CreateExperimentEntryTransform(experimentEntry, entryContainer, entryTransformList);
    //    }

    //}


    private void CreateExperimentEntryTransform(ExperimentEntry experimentEntry, Transform container, List<Transform> transformList)
    {
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
                rankString = rank + "TH"; break;

            case 1: rankString = "1st"; break;
            case 2: rankString = "2nd"; break;
            case 3: rankString = "3rd"; break;

        }

        entryTransform.Find("experiment").GetComponent<Text>().text = rankString;

        float oil = experimentEntry.oil;//TODO read volume from slider 
        entryTransform.Find("Oil").GetComponent<Text>().text = oil.ToString();

        float lye = experimentEntry.lye;//TODO read volume from slider 
        entryTransform.Find("Lye").GetComponent<Text>().text = lye.ToString();

        float result = experimentEntry.result; //TODO from Saponification Script, result text
        entryTransform.Find("Result").GetComponent<Text>().text = result.ToString();

        //////Set background visible odds and evens, easier to read
        //entryTransform.Find("background").gameObject.SetActive(rank % 2 == 1);//activate background
        ////Highlight first
        //if (rank == 1)
        //{

        //    entryTransform.Find("Result").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("Oil").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("Lye").GetComponent<Text>().color = Color.green;
        //    entryTransform.Find("experiment").GetComponent<Text>().color = Color.green;
        //}
    


        transformList.Add(entryTransform);
    }

    private void AddExperimentEntry(float oil, float lye, float result)
    {
        //Create ExperimentEntry
        ExperimentEntry experimentEntry = new ExperimentEntry { lye = lye, oil = oil, result = result };

        //Load saved Experiments
        string jsonString = PlayerPrefs.GetString("experimentsTable");
        Experiments experiments = JsonUtility.FromJson<Experiments>(jsonString);

        //Add new entry to ExperimentsTable
        experiments.experimentEntriesList.Add(experimentEntry);

        //Saved updated ExperimentsTable
        string json = JsonUtility.ToJson(experiments);
        PlayerPrefs.SetString("experimentsTable", json);
        PlayerPrefs.Save();
    }


    //TODO read the values from the other scripts (saponification, AddVolume)
    [System.Serializable]
    private class ExperimentEntry //object that contains the values
    {
        public float oil;
        public float lye;
        public float result;

    }

    private class Experiments//object that contains the list of experiments
    {
        public List<ExperimentEntry> experimentEntriesList;

    }
}

