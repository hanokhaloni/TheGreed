using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int PlayerOneScore = 0;
    public int PlayerTwoScore = 0;

    public float timeLeft = 60.0f;

    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;
    public Text TimeRemainingText;




    public Text GameOverText;

    // Use this for initialization
    void Start () {

    }


    public void UpdateTime()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }

        if (timeLeft > 0.0f)
        {
            TimeRemainingText.text = string.Format("{0:#,##} Seconds", timeLeft);

        }
        else
        {
            TimeRemainingText.text = "OUT OF TIME!";
        }

    }

    public void GameOver()
    {
        GameOverText.enabled = true;
    }

    // Update is called once per frame
    void Update () {
        UpdateTime();


    }

    public void IncrementPlayerScore(int playerNumber)
    {
        if (playerNumber == 1)
        {
            IncrementPlayerOneScore();
        }

        if (playerNumber == 2)
        {
            IncrementPlayerTwoScore();
        }
    }

    public void IncrementPlayerOneScore()
    {
        PlayerOneScore++;
        PlayerOneScoreText.text = PlayerOneScore.ToString();
    }

    public void IncrementPlayerTwoScore()
    {
        PlayerTwoScore++;
        PlayerTwoScoreText.text = PlayerTwoScore.ToString();
    }

}
