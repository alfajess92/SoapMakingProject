using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorBehaviourScript : MonoBehaviour
{
	Animator anim;
	AnimatorOverrideController animOverrideController;
	AnimationClip animationClip;

	protected int weaponIndex;

	// Use this for initialization
	void Start()
	{

	}



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

				//create animation clip
				AnimationCurve translateX = AnimationCurve.Linear(0.0f, 0.0f, 2.0f, 2.0f);
				animationClip = new AnimationClip();
				animationClip.SetCurve("", typeof(Transform), "localPosition.x", translateX);

				anim = GetComponent<Animator>();
				AnimatorOverrideController animatorOverrideController = new AnimatorOverrideController();
				animatorOverrideController.runtimeAnimatorController = anim.runtimeAnimatorController;
				animatorOverrideController["animate_ladle"] = animationClip;
				anim.runtimeAnimatorController = animatorOverrideController;
			}

		}

	}
}