using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickObjects : MonoBehaviour
{

    public PropertiesAndCoroutines coroutineScript;



    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {
                Vector3 newTarget = Hit.point + new Vector3(0, 0.5f, 0);
                coroutineScript.Target = newTarget;
            }
        }
    }

}