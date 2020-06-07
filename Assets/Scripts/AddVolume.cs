using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddVolume : MonoBehaviour
{

    //public float volumeincrease= 0.1f;
    public GameObject liquidMesh, beaker;
    Transform liquidMeshTransform;

    //Vector3 changeVolume = new Vector3(0, 1f, 0);
    Vector3 currentVolume;

    public Slider MySlider;

    private void Start()
    {

        liquidMeshTransform= beaker.transform.Find("Liquid");
        //if (liquidMesh != null)
        //{
        //    Debug.Log("A child with the name 'liquid' attached to the player");
        //}

        //currentVolume = liquidMesh.transform.localScale;
        //liquidMeshTransform.localScale;
        //print(currentVolume);
        //changeVolume = new Vector3(1f, volumeincrease, 1f);

    }

    



        ////liquidMesh = GameObject.Find("Liquid");
        

        //liquidMeshTransform = GetComponentInChildren<Transform>();
        //currentVolume = liquidMeshTransform.localScale;

       
    



////Update is called once per frame
//void Update()
//{
//    AdjustVolume();
//}

public void AdjustVolume()
{
        //changeVolume.y += Time.deltaTime * volumeincrease;
        //currentVolume += changeVolume;
        print("adding volume");


        //currentVolume = Vector3.Scale(currentVolume, changeVolume);

        //liquidMeshTransform.localScale = changeVolume;
        //liquidMesh.transform.localScale +=changeVolume;

        liquidMeshTransform.localScale = new Vector3(liquidMeshTransform.localScale.x, MySlider.value, liquidMeshTransform.localScale.z);



    }



}
