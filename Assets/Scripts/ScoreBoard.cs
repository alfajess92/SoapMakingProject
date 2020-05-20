using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//need it for text and canvas

public class ScoreBoard : MonoBehaviour
{
    [SerializeField] int scorePerSoap = 1;

    int score;
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreSoap()
    {
        score = score + scorePerSoap;
        scoreText.text = score.ToString();
    }
}
