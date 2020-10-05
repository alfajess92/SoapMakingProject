//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Assertions.Must;
using UnityEngine.UI;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.Networking;

public class InputManagerProcess : MonoBehaviour
{
   // public Camera MainCamera;
    public GameObject KOHValve;
    public GameObject Steam;
    public GameObject Mixer;
    public ParticleSystem.MainModule mainSteam;
    public Slider slider;
    public TMPro.TextMeshProUGUI titleText;
    public TMPro.TextMeshProUGUI valueText;
    public TMPro.TextMeshProUGUI temperatureText;
    public TMPro.TextMeshProUGUI soapText;
    public double soapValue;
    public double soapValueTotal=0.6;
    public double soapValueLimit;
    //public GameObject nextScenePanel;
    public TMPro.TextMeshProUGUI totalSoapText;
    public PanelManagerScript panelManagerScript;
    public TextAsset dataAsset;


    double[,] dataTable;
    float[] values;
    string[] names;
    string[] units;

    List<GameObject> selectables;
    int selectedIndex;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        values =new float[] { 0, 0, 0 };
        names =new string[] { "KOH Valve", "Steam" , "Mixer"};
        units =new string[] { "kg/h", "kcal/h", "rpm" };
        var formatter = new BinaryFormatter();
        //FileStream stream = File.OpenRead(Application.dataPath+ System.IO.Path.DirectorySeparatorChar +"Process"+ System.IO.Path.DirectorySeparatorChar + "dataTableSoap");
        //FileStream stream = File.OpenRead(Application.streamingAssetsPath + System.IO.Path.DirectorySeparatorChar + "dataTableSoap");
        //var path = "jar:file://" + Application.streamingAssetsPath + "!/assets/" + System.IO.Path.DirectorySeparatorChar + "dataTableSoap";
        //var path = "jar:file://" + Application.streamingAssetsPath + Path.DirectorySeparatorChar + "dataTableSoap";

        //For Android
        //string path = Path.Combine("jar:file://" + Application.streamingAssetsPath + "!/assets/"+ "dataTableSoap");


        //Debug.Log("Deserializing vector");

        //Testing for android
 /*       string sFilePath = Path.Combine(Application.streamingAssetsPath + Path.DirectorySeparatorChar + "dataTableSoap");
        //string sFilePathAndroid = Path.Combine("jar:file://" +Application.dataPath + Path.DirectorySeparatorChar + "Process" + Path.DirectorySeparatorChar + "dataTableSoap");
        string sFilePathAndroid = Path.Combine("jar:file://" + Application.streamingAssetsPath + Path.DirectorySeparatorChar + "dataTableSoap");

        print(sFilePath);
        string sData;
        if (Application.platform == RuntimePlatform.Android)
        {
            UnityWebRequest www = UnityWebRequest.Get(sFilePathAndroid);
            www.SendWebRequest();
            while (!www.isDone) ;
            sData = www.downloadHandler.text;
        }
        //else sData= File.ReadAllText(sFilePath);
        else sData = sFilePath;
        print(sData);

        FileStream stream = File.OpenRead(sData);

        */
        

        string item = "data/dataTableSoap";

        string androidFilePath = System.IO.Path.Combine(Application.streamingAssetsPath, item);
        // string androidFilePath = Application.streamingAssetsPath +"/"+ item;
      /*  string jsonstring;

        if(Application.platform==RuntimePlatform.Android)
        { WWW reader = new WWW(androidFilePath);
            while (!reader.isDone) { }

            jsonstring = reader.text;
        }
        else
        {
            jsonstring = androidFilePath;
        }
        */

        //TextAsset allData = Resources.Load("Data" + Path.DirectorySeparatorChar + "dataTableSoap") as UnityEngine.TextAsset;
        //temperatureText.text = allData.text;
        BinaryFormatter br = new BinaryFormatter();
        dataTable = (double[,])br.Deserialize(new MemoryStream(dataAsset.bytes));

        //FileStream stream = allData.bytes;
        //dataTable = (double[,])allData.bytes;
        //Debug.Log(jsonstring);

        //FileStream stream = File.Open(jsonstring, FileMode.Open);
        //dataTable = (double[,])formatter.Deserialize(stream);
        //stream.Close();


        //dataTable = new double[,] { { 3, 3, 3, 0, 0 }, { 3, 3, 3, 0, 0 } };

        /*  ParticleSystem ps = Steam.GetComponent<ParticleSystem>();
          ParticleSystem.MainModule mainSteam = ps.main;
          mainSteam.startColor = Steam.GetComponent<SpriteRenderer>().color;*/
        selectables = new List<GameObject>();
        selectables.Add(KOHValve);
        selectables.Add(Steam);
        selectables.Add(Mixer);
        selectedIndex = 0;


        slider.gameObject.SetActive(false);

        foreach (GameObject selected in selectables)
                { UnSelect(selected); }
        //Select(KOHValve);
        Recompute();
    }

    // Update is called once per frame
    void Update()
    {
        soapValueTotal += soapValue * Time.deltaTime;
        totalSoapText.text = "Soap produced: " + soapValueTotal.ToString("0") + "/" + soapValueLimit.ToString("0") + "kg" ;
        if (soapValueTotal> soapValueLimit)
        {
            slider.gameObject.SetActive(false);
            //nextScenePanel.SetActive(true);
            panelManagerScript.EnterNextScenePanel();
        }
        else 
        {
            if (values[selectedIndex] != slider.value)
            {
                values[selectedIndex] = slider.value;
                Recompute();
            }

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit Hit;

            if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
            {
                foreach (GameObject obj in selectables)
                {
                    if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == obj && !IsSelected(obj))
                    {
                        Select(obj);
                    }
                }
            }
        }
        
    }

    void UnSelect(GameObject gameObject)
    {
        if(gameObject==KOHValve || gameObject == Mixer)
        {
            Material[] materials = gameObject.GetComponent<MeshRenderer>().sharedMaterials;
            //materials[materials.Length - 1].SetFloat("_FirstOutlineWidth", 0);
            //materials[materials.Length - 1].SetFloat("_SecondOutlineWidth", 0);
            materials[materials.Length - 1].SetColor("_FirstOutlineColor", new Color(0.4f, 1, 0.4f));
            materials[materials.Length - 1].SetColor("_SecondOutlineColor", new Color(0.4f, 1, 0.4f));
            //materials[materials.Length - 1].SetFloat("_FirstOutlineWidth", 25);
            //materials[materials.Length - 1].SetFloat("_SecondOutlineWidth", 25);

        }
        else if (gameObject== Steam)
        { gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.4f, 1, 0.4f); }
    }

    void Select(GameObject gameObject)
    {
        gameObject.GetComponent<ChatTrigger>().TriggerChat();
        slider.gameObject.SetActive(true);

        foreach (GameObject obj in selectables) { UnSelect(obj); }

        if (gameObject == KOHValve || gameObject == Mixer)
        {
            Material[] materials = gameObject.GetComponent<MeshRenderer>().sharedMaterials;
            materials[materials.Length - 1].SetColor("_FirstOutlineColor", new Color(1, 1, 0.4f));
            materials[materials.Length - 1].SetColor("_SecondOutlineColor", new Color(1, 1, 0.4f));
            //materials[materials.Length - 1].SetFloat("_FirstOutlineWidth", 25);
            //materials[materials.Length - 1].SetFloat("_SecondOutlineWidth", 25);
        }
        else if (gameObject == Steam)
        { gameObject.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 0); }

        for (int i=0; i<selectables.Count; i++)
        { if (selectables[i]==gameObject) { selectedIndex = i; } }

        titleText.text = names[selectedIndex];
        slider.value = values[selectedIndex];
        valueText.text = DisplayValue(gameObject,values[selectedIndex]).ToString("0.0") + " " + units[selectedIndex];

    }
    bool IsSelected(GameObject gameObject)
    {
        if (selectables[selectedIndex] == gameObject) { return true; }
        else { return false; }
    }
    void Recompute() 
    {
        valueText.text = DisplayValue(selectables[selectedIndex],values[selectedIndex]).ToString("0.0") + " " + units[selectedIndex];

        double[] realValues= new double[3];
        double oldDist=Math.Pow(10,10); double newDist; int index=0;

        for (int i = 0; i < selectables.Count; i++)
        {
            realValues[i] = RealValue(selectables[i], values[i]);
        }
        for (int i = 0; i <= dataTable.GetUpperBound(0); i++)
        //foreach (int i in System.Linq.Enumerable.Range(0, 1000))

        {
            newDist = Math.Pow(realValues[0]-dataTable[i, 0],2) + Math.Pow(realValues[1]-dataTable[i, 1],2) + Math.Pow(realValues[2]-dataTable[i, 2],2);
            if (newDist < oldDist) { oldDist = newDist; index = i; }
        }

        soapValue = dataTable[index, 3] * 360;
        temperatureText.text = "Temperature: \n " + dataTable[index, 4].ToString("0.0")+"C";
        soapText.text = "Soap flow: \n " + soapValue.ToString("0.000")+ "kg/h";
//        Debug.Log(dataTable[index, 3]);
//        Debug.Log(dataTable[index, 4]);


    }

    double RealValue(GameObject gameObject, double value) 
    {
        double result=0;
        if (gameObject == KOHValve) { result= value / 10 * 70; }
        if (gameObject == Steam) { result= value / 10 * 4000; }
        if (gameObject == Mixer) { result= 0.00116 * Math.Pow(10, ((10-value) * -2));         }
        return result;
    }

    double DisplayValue(GameObject gameObject, double value)
    {
        double result = 0;
        if (gameObject == KOHValve) { result = RealValue(gameObject, value); }
        if (gameObject == Steam) { result = RealValue(gameObject, value); }
        if (gameObject == Mixer) { result = value*20; }
        return result;
    }



}