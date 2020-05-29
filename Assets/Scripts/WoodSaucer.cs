using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WoodSaucer : MonoBehaviour
{
   [SerializeField] SpillScriptWoodSaucer spill;
    Animator animatorWoodSaucer, animatorWaterAsh, animatorAsh;

    AudioSource audiosourceWoodSaucer;
    public GameObject waterAsh, ash;
    public bool isTouchWoodsaucer = false;
    public bool isEmpty = false;

    // Start is called before the first frame update
    void Start()
    {
        animatorWoodSaucer = GetComponent<Animator>();
        audiosourceWoodSaucer = GetComponent<AudioSource>();

        waterAsh = GameObject.Find("WaterProDaytime");
        animatorWaterAsh = waterAsh.GetComponent<Animator>();

        ash= GameObject.Find("ash2");
        animatorAsh = ash.GetComponent<Animator>();
    }

   public void ServeWaterWoodSaucer()
    {
        Debug.Log("echale");
        animatorWoodSaucer.SetTrigger("ServeAsh");
        isTouchWoodsaucer = true;
       
    }

    public void EmptyWoodSaucer()
    {
        animatorWaterAsh.SetTrigger("EmptyWoodSaucer");
    }


    public void DissapearAsh()
    {
        animatorAsh.SetTrigger("Dissapear");
    }


    public void PlayWaterStream()
    {
        spill.PlayWaterStreamWoodSaucer();
    }

    public void StopWaterStream()
    {
        spill.StopWaterStreamWoodSaucer();
    }


    public void PlaySoundWoodSaucerStream()//TODO check if this has to be here

    {
        if (!audiosourceWoodSaucer.isPlaying)                    //if the audio is not playing

        {
            audiosourceWoodSaucer.Play();
        }

        else

        {
            audiosourceWoodSaucer.Stop();
        }

    }




}
