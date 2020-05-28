using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{

    public GameObject ladle, teapot, woodsaucer;
    public UnityEvent OnClick = new UnityEvent();
    

    //// Start is called before the first frame update
    void Start()

    {

        ladle = GameObject.Find("Soup_Ladle_A");//Find the object with this name in the world
        ladle.GetComponent<LadleScript>().enabled = false;


        teapot = GameObject.Find("Teapot");//Find the object with this name in the world
        teapot.GetComponent<ServeWater>().enabled = false;



        woodsaucer = GameObject.Find("Wood_Saucer");//Find the object with this name in the world
        woodsaucer.GetComponent<WoodSaucer>().enabled = false;

    }



    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ya encontre la cuchara");
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == teapot)
            {
                Debug.Log("ya vamos activando la fiesta");
                ladle.GetComponent<LadleScript>().enabled = true;
                teapot.GetComponent<ServeWater>().enabled = true;
                woodsaucer.GetComponent<WoodSaucer>().enabled = false;
            }
            
        }

    }

}