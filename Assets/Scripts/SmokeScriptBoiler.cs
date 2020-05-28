using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeScriptBoiler : MonoBehaviour
{
    ParticleSystem boilerSmoke;
    // Start is called before the first frame update
    void Start()
    {
        boilerSmoke = GetComponent<ParticleSystem>();
        StopSmokeBoiler();
    }

    public void PlaySmokeBoiler()
    {
        Debug.Log("Esto ya se esta calentando");
        boilerSmoke.Play();
    }

    public void StopSmokeBoiler()
    
    {
        boilerSmoke.Stop();
    }
}
