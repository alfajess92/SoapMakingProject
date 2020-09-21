using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//need it for text and canvas
using UnityEngine.SceneManagement;


public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerSoap = 0;//maybe should be in teapot
    public PanelManagerScript panelManagerScript;
    public ChatManager chatManagerScript;
    public ChatTrigger chatObject;
    int score;
    Text scoreText;

    //public ChatTrigger winningChat;
    //enum State {Scenesoap, Scenelab, Trascending}
    //State state = State.Scenesoap;

    

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: "+ score.ToString();
        //winningChat = FindObjectOfType<ChatTrigger>();
    }


    public void ScoreSoap()
    {
        score += scorePerSoap;
        scoreText.text = "Score: +" + score.ToString();
        //winningChat.TriggerChat();
        StopChat();
        print("the chat is gone forever");
        Invoke("NextLevel", 5f);//parameterise time
        //NextLevel();

    }

    //To ensure that the chat is not 
    public void StopChat()
    {
        if (score > 1)
        {
            //TODO find a better way to remove the chat after reaching score+1 which means ladle was touch once.
            chatObject.EndChatAfterTouch();
            print("the chat is gone forever");

            //Destroy(GetComponent<ChatTrigger>());
            //print("ChatTrigger of Laddle is off");
        }

    }


    public void NextLevel()
    {
        if (score >= 3)
        {
            chatManagerScript.EndChat();
            panelManagerScript.EnterNextScenePanel();

            
        }
    }


}
