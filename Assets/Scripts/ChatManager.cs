using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public Queue<string> sentences;
    public Text chat;
    public Animator animator;


    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartChat(Chat chat)
    {

        Debug.Log("Starting Chat");
        animator.SetBool("isOpen", true);
        sentences.Clear();

        foreach (string sentence in chat.sentences)// loop into the chat to load all sentences
        {
            sentences.Enqueue(sentence);//adds to end of queue
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        //check if there are sentences in the queue
        if (sentences.Count == 0)//this means end of the chat
        {
            EndChat();
            return;
        }

        string sentence = sentences.Dequeue();// returns the front of the queue

        StopAllCoroutines();//To stop if any type sentences has started before
        //Debug.Log(sentence);
        //chat.text = sentence; //instead called coroutine
        StartCoroutine(TypeSentence(sentence));

    }

    //To animate each letter add coroutine
    IEnumerator TypeSentence(string sentence)
    {
        chat.text = "";
        foreach (char letter in sentence.ToCharArray())//loop on each character and ToCharArray will convert a string into a character array
        {
            chat.text += letter; //to append the letters
            yield return null;
            //yield return new WaitForEndOfFrame();
        }


    }

    private void EndChat()

       {
            //Debug.Log("end");
            animator.SetBool("isOpen", false);
       }

    
}
