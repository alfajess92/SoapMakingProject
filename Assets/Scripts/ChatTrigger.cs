using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatTrigger : MonoBehaviour
{
    public Chat chat;


    public void TriggerChat()
    {
        FindObjectOfType<ChatManager>().StartChat(chat);
    }

   
}
