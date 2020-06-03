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
        Invoke("NextLevel", 1f);//parameterise time
        //NextLevel();

    }


    //public void NextLevel()
    //{
    //    if (score >= 3)
    //    {
    //        SceneManager.LoadScene(1);// todo allow for more than 2 levels
    //    }

    //}

    
    public void NextLevel()
    {
        if (score >= 3)
        {
            chatManagerScript.EndChat();
            panelManagerScript.EnterNextScenePanel();
           
        }
    }


}
