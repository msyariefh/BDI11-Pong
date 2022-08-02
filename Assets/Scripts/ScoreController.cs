using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TMP_Text leftScoreBoard;
    public TMP_Text rightScoreBoard;

    public ScoreManager manager;

    private void Update()
    {
        leftScoreBoard.text = ScoreToString(manager.leftScore);
        rightScoreBoard.text = ScoreToString(manager.rightScore);

    }

    private string ScoreToString(int score)
    {
        if (score > 9) return score.ToString();
        return "0" + score;
    }
}
