using UnityEngine;

public class SpillScriptOil : MonoBehaviour
{
    //TODO this script maybe can be generic
    ParticleSystem oilStream;

    void Start()
    {
        oilStream = GetComponent<ParticleSystem>();
        StopOilStream();
    }


    public void PlayOilStream()//to add in the animator controller as a parameter
    {
        oilStream.Play();
    }

    public void StopOilStream()
    {
       oilStream.Stop();
    }
}
