using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animator_test : MonoBehaviour
{
    AnimationClip m_anim;
    Transform m_trans;
    Animation m_animation;
    
    

    const string m_clip_name_move = "M";

    void Start()
    {  // get local transform matrix & animation
        m_trans = transform;
        m_animation = GetComponent<Animation>();

        // create the animation clip for moving in 3 dimensions
        m_anim = new AnimationClip();
        
    }

    public void AnimateToPosition()
    {  // play the animation
        m_anim.ClearCurves();
        Vector3 pos = m_trans.localPosition;
        Vector3 dest = new Vector3(5f, 2f, 3f);
        float speed = 1.0f;
        AnimationCurve curve_x = AnimationCurve.Linear(0, pos.x, speed, dest.x);
        AnimationCurve curve_y = AnimationCurve.Linear(0, pos.y, speed, dest.y);
        AnimationCurve curve_z = AnimationCurve.Linear(0, pos.z, speed, dest.z);
        m_anim.SetCurve("", typeof(Transform), "localPosition.x", curve_x);
        m_anim.SetCurve("", typeof(Transform), "localPosition.y", curve_y);
        m_anim.SetCurve("", typeof(Transform), "localPosition.z", curve_z);
        m_animation.AddClip(m_anim, m_clip_name_move);
        m_animation.Play(m_clip_name_move);
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
                AnimateToPosition();

            }

        }

    }

}
