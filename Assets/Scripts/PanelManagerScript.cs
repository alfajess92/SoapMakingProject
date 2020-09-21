using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagerScript : MonoBehaviour
{

    public Animator animator;
    

    public void EnterNextScenePanel()
    {
        animator.SetBool("isOn", true);
        
    }

    public void ExitNextScenePanel ()

    {
        //Debug.Log("end");
        animator.SetBool("isOn", false);
    }
}
