using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class StartingProcessScript : MonoBehaviour
{

    public GameObject toHighlight;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("working");

       // FileStream stream = File.Create(@"C:\Users\u0128100\Documents\SoapMakingProject-master\Assets\Process\Mirame.txt");
        var formatter = new BinaryFormatter();
        FileStream stream = File.OpenRead(@"C:\Users\u0128100\Documents\Mirame.txt");
        Debug.Log("Deserializing vector");
        double[,] amame = (double[,])formatter.Deserialize(stream);
        stream.Close();

        foreach (int i in System.Linq.Enumerable.Range(0, 1000))
        {
            Debug.Log(amame[i, 0]);
            Debug.Log(amame[i, 1]);
            Debug.Log(amame[i, 2]);
        }

        toHighlight.GetComponent<Renderer>().material.color = new Color32(0,255,10, 255);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
