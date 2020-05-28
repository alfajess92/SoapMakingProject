using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//need it for text and canvas
using UnityEngine.SceneManagement;


public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerSoap = 0;//maybe should be in teapot

    int score;
    Text scoreText, nextScene;
    enum State {Scenesoap, Scenelab, Trascending}
    State state = State.Scenesoap;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
        
    }


    public void ScoreSoap()
    {
        score += scorePerSoap;
        scoreText.text = "+" + score.ToString();
        //NextLevel();
        //state = State.Trascending;
        Invoke("NextLevel", 5f);//parameterise time
    }


    public void NextLevel()
    {
        if (score >= 1)
        {
            //nextScene.text = "You are the master of soap making";
            SceneManager.LoadScene(1);// todo allow for more than 2 levels
        }

    }

    
    
}
