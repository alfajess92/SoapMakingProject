using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddVolume : MonoBehaviour
{

    public float volumeincrease= 10f;
    public GameObject liquidMesh;
    Transform liquidMeshTransform;
    
    Vector3 currentVolume;
    [SerializeField]
    //Transform liquidMeshTransform;
    // Start is called before the first frame update
    void Start()
    {

        liquidMeshTransform = GetComponentInChildren<Transform>();
        currentVolume = liquidMeshTransform.localScale;
    }

    ////Update is called once per frame
    //void Update()
    //{
    //    AdjustVolume(volumeincrease);
    //}

    public void AdjustVolume(float volumeincrease)
    {
        currentVolume.y += Time.deltaTime * volumeincrease;
        //currentVolume.y += Time.deltaTime * volumeincrease;

        liquidMeshTransform.localScale = currentVolume;
    }
}
