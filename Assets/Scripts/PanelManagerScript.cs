using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManagerScript : MonoBehaviour
{

    public Animator animator;

    //object to activate/deactivate when the panel is on/off
    public GameObject table, resultbox;


    private void Awake()
    {
        table = GameObject.Find("ResultsTable");
        resultbox= GameObject.Find("ResultBox");
    }

    public void EnterNextScenePanel()
    {
        animator.SetBool("isOn", true);
        table.SetActive(false);
        resultbox.SetActive(false);
    }

    public void ExitNextScenePanel ()

    {
        //Debug.Log("end");
        animator.SetBool("isOn", false);
        table.SetActive(true);
        resultbox.SetActive(true);
    }

   
}
