using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager2 : MonoBehaviour
{

    public Animator animator;

    //object to activate/deactivate when the panel is on/off
    public GameObject table, resultbox, ChatBox, StartButton;


    private void Awake()
    {
        table = GameObject.Find("ResultsTable");
        resultbox = GameObject.Find("ResultBox");
        ChatBox= GameObject.Find("ChatBox");
        StartButton = GameObject.Find("StartButton");
    }

    public void EnterNextScenePanel()
    {
        animator.SetBool("isOn", true);
        table.SetActive(false);
        resultbox.SetActive(false);
        ChatBox.SetActive(false);
        StartButton.SetActive(false);
        
    }

    public void ExitNextScenePanel()

    {
        //Debug.Log("end");
        animator.SetBool("isOn", false);
        table.SetActive(true);
        resultbox.SetActive(true);
        ChatBox.SetActive(true);
        StartButton.SetActive(true);


    }

}
