using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rb;
    public Vector2 resetPosition;
    private GameObject lastPaddleTouch;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
    }

    public void ResetBallPosition()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 0);
        rb.velocity = speed;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rb.velocity *= magnitude;
    }

    public void UpdateLastPaddleTouch(GameObject paddle)
    {
        lastPaddleTouch = paddle;
    }

    public GameObject GetLastPaddleTouch()
    {
        return lastPaddleTouch;
    }
    
}
