using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PULongerPadlleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int multiplier;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != ball) return;

        GameObject go = ball.gameObject.GetComponent<BallController>().GetLastPaddleTouch();
        if (go == null) return;
        manager.AddPaddleLongerEffect(go, multiplier);
        Destroy(gameObject);
    }
}
