using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFasterPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int multiplier;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != ball) return;

        GameObject go = ball.gameObject.GetComponent<BallController>().GetLastPaddleTouch();
        if (go == null) return;
        manager.AddPaddleFasterEffect(go, multiplier);
        Destroy(gameObject);
    }
}
