using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class CoronaGrow : MonoBehaviour

{

    float count;

    public GameObject GrowingCorona;

    public GameObject endScreen;

    



    // Update is called once per frame

    void Update()

    {

            GrowingCorona.transform.localScale = GrowingCorona.transform.localScale * (1+Time.deltaTime/10);

            count += Time.deltaTime;

        

        if (count > 15)

        { endScreen.SetActive(true); }



    }

}