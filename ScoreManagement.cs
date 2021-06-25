using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManagement : MonoBehaviour
{
    // Start is called before the first frame update
    public Text ScoreText;
    private float timer;
    private int score = 0;

    private int scoreLenght = 6;

    private int numZeros = 0;
    private string scoreString;
    private string newScore;
    void Start()
    {

    }

    public int getScore() {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f)
        {

            score += 50;
            scoreString = score.ToString();
            numZeros = scoreLenght - scoreString.Length;

            for (int i = 0; i < numZeros; i++)
            {
                newScore += "0";
            }
            newScore += scoreString;
            ScoreText.text = "Score : " + newScore;
            timer = 0;
            newScore = "";
            scoreString = "";
        }
    }
}
