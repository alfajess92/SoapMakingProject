using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Events;

public class ServeWater : MonoBehaviour
{



    public GameObject definedButton;
    public UnityEvent OnClick = new UnityEvent();
    Animator animator;
    Vector3 position;

    //// Start is called before the first frame update
    void Start()


    {
        definedButton = this.gameObject;
        animator = GetComponentInParent<Animator>();

        position = definedButton.transform.localPosition;
    }



    // Update is called once per frame
    void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit Hit;

        if (Input.GetMouseButtonDown(0))//zero refers to the right click of the mouse
        {
            if (Physics.Raycast(ray, out Hit) && Hit.collider.gameObject == gameObject)
            {

                animator.SetTrigger("Serve");//inside the animator controller


            }




        }


    }

}
