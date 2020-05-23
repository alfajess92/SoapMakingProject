using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpillScript : MonoBehaviour
{
    ParticleSystem waterStream;
    // Start is called before the first frame update
    void Start()
    {
        waterStream = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Angle(Vector3.down, transform.forward) <= 90f)
        {
            waterStream.Play();

        }
        else
        {
            waterStream.Stop();
        }
    }
}
