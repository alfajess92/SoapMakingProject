using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChatTrigger : MonoBehaviour
{
    public Chat chat;
    //public Animator animator;


    public void TriggerChat()
    {
        FindObjectOfType<ChatManager>().StartChat(chat);//This will load into the function what is contained in ChatTriggerObject
    }


    public void EndChatAfterTouch()
    {
        FindObjectOfType<ChatManager>().EndChatForever();
      
    }
   
}
