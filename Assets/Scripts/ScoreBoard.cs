using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//need it for text and canvas
using UnityEngine.SceneManagement;


public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerSoap = 0;//maybe should be in teapot

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
        Invoke("NextLevel", 10f);//parameterise time
    }


    public void NextLevel()
    {
        if (score >= 3)
        {
            SceneManager.LoadScene(1);// todo allow for more than 2 levels
        }

    }



}
