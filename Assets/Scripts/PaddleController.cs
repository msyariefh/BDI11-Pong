using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode UpKey;
    public KeyCode DownKey;
    public int speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle(GetInput());
    }

    private Vector3 GetInput()
    {

        if (Input.GetKey(UpKey))
        {
            return Vector3.up * speed;
        }

        if (Input.GetKey(DownKey))
        {
            return Vector3.down * speed;
        }

        return Vector3.zero;
    }

    private void MovePaddle(Vector3 direction)
    {
        rb.velocity = direction;
        Debug.Log("Kecepatan " + gameObject.name + ": " + rb.velocity.ToString());
    }

}
