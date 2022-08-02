using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public int maxScore;
    public int leftScore;
    public int rightScore;
    public BallController ball;
    public PowerUpManager manager;

    public void AddLeftScore(int increments)
    {
        leftScore += increments;
        manager.RemoveAllPowerUp();
        ball.ResetBallPosition();
        if (leftScore >= maxScore)
        {
            GameOver();
        }
    }

    public void AddRightScore(int increments)
    {
        rightScore += increments;
        manager.RemoveAllPowerUp();
        ball.ResetBallPosition();
        if (rightScore >= maxScore)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }
}
