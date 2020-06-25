using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassRod : MonoBehaviour
{


    public GameObject parentGlassRod;

    Animator animatorGlassRod;
    //ScoreBoard scoreBoard;

    public bool isTouchGlassRod = false;
    float glassRodClipLength;
    ChatTrigger chat;


    // Start is called before the first frame update
    void Start()
    {
        parentGlassRod= GameObject.Find("Parent_GlassRod");//Find the object with this name in the world
        animatorGlassRod= parentGlassRod.GetComponent<Animator>();
        //scoreBoard = FindObjectOfType<ScoreBoard>();//too look the scoreboard in the world
        chat = GetComponent<ChatTrigger>();

        AnimationClip[] clipsGlassRod = animatorGlassRod.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clipsGlassRod)

        {
            glassRodClipLength = clip.length;
        }


    }


    public void MoveGlassRod()
    {
        animatorGlassRod.SetTrigger("Mix");//inside the animator controller
        //StartSmoke();
        //scoreBoard.ScoreSoap();
        //isTouchLadle = true;
        print(glassRodClipLength);

        //Invoke("TouchLadle", ladleClipLength);//
        TouchGlassRod();
        //print("the chat is gone forever");
        //chat.EndChatAfterTouch();//after appearing once the chat of the ladle will be deactivated


    }


    public void TouchGlassRod()
    {
        isTouchGlassRod = false;
    }

}
