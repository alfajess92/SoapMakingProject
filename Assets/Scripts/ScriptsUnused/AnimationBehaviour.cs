using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
//[RequireComponent(typeof(LadleScript))]
public class AnimationBehaviour : MonoBehaviour
{
	public Animation anim;
	//public LadleScript spoon;
	AnimationClip animationClip, animationClipReturn;
    Transform transformValue;
	//Animator animator;
	//Vector3 positionSpoon;
	


	void Start()
	{
		anim = GetComponent<Animation>();
        transformValue = GetComponent<Transform>();

		//animator = GetComponent<Animator>();
  //      spoon = GetComponent<LadleScript>();
  //      positionSpoon = spoon.transform.localPosition;
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

				// define animation curve
				Debug.Log("Hice click");

                
                AnimationCurve translateX = AnimationCurve.Linear(0.0f, 0.0f, 1.0f, 1.0f);
                AnimationCurve translateX2 = AnimationCurve.Linear(1.0f, 1.0f, 2.0f, 0.0f);




                animationClip = new AnimationClip();
                // set animation clip to be legacy
                animationClip.legacy = true;

                //animator.SetTrigger("lol");//inside the animator controller
                animationClip.SetCurve("", typeof(Transform), "localPosition.x", translateX);

                animationClipReturn = new AnimationClip();
                animationClipReturn.legacy = true;
                animationClipReturn.SetCurve("", typeof(Transform), "localPosition.x", translateX2);
                //animationClip.SetCurve("", typeof(Transform), "localPosition.z", translateX);

                //AnimationCurve rotateX = AnimationCurve.Linear(0.0f, 0.0f, 2.0f, 90.0f);
                //animationClip = new AnimationClip();
                //animationClip.SetCurve("", typeof(Transform), "localEulerAngles.x", rotateX);

                anim.AddClip(animationClip, "test");
                anim.Play("test");
                anim.AddClip(animationClipReturn, "return");
                anim.Play("return");
            }


        }


    }

}