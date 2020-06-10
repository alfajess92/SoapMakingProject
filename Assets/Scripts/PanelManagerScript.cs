using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagerScript : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
