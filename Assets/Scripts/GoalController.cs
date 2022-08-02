using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public Collider2D ball;
    public enum Goal
    {
        RIGHT, LEFT
    }
    public Goal goalPosition;
    public ScoreManager manager;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != ball) return;

        switch (goalPosition)
        {
            case Goal.LEFT:
                manager.AddRightScore(1);
                break;
            case Goal.RIGHT:
                manager.AddLeftScore(1);
                break;
        }
    }
}
