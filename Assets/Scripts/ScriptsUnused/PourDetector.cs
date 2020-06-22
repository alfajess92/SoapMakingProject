using System;
using System.Collections;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public int pourThreshold = 45;
    public Transform origin = null;
    public GameObject streamPrefab = null;


    private bool isPouring = false;
    private Stream currentStream = null;


    private void Update()
    {
        bool pourCheck = CalculatePourangle() < pourThreshold;

        if (isPouring!= pourCheck)
        {
            isPouring = pourCheck;
            if (isPouring)
            {
                StartPour();
            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        //empty
        print("Start");
        currentStream = CreateStream();
        currentStream.Begin();
    }

    private void EndPour()
    {

        currentStream.End();
        currentStream = null;
        print("End");

    }


    private float CalculatePourangle()
    {
        return transform.forward.y * Mathf.Rad2Deg;  //forward bcs of the mesh we are using, other can be up, video 2 min 7:40
    }

    private Stream CreateStream()
    {
        GameObject streamObject = Instantiate(streamPrefab, origin.position, Quaternion.identity, transform);//rotation of zero (quaternion)
        return streamObject.GetComponent<Stream>();
    }

}