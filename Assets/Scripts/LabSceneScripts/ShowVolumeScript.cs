using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowVolumeScript : MonoBehaviour
{
    // Start is called before the first frame update


    public Text volumeText;

    public static float volume = 0.0f;

    public float factorVolume;

    void Start()

    {
        volumeText = GetComponent<Text>();
        volume = 0.0f;
    }


    public void textUpdate(float volume)
    {
        volumeText.text = (volume *100*factorVolume).ToString("F1");

    
      
    }

    public void DeleteText()
    {
        volumeText.text=volume.ToString("F1");

    }



}
