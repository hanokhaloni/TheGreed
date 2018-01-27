using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public int PlayerOneScore = 0;
    public int PlayerTwoScore = 0;

    public Text PlayerOneScoreText;
    public Text PlayerTwoScoreText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
