using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    public Rigidbody2D rb2d;
    bool isgrounded = true;
    public GameManagement gameManagement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
    }

    void Update()
    {
        if (isgrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb2d.velocity = Vector2.up * jumpForce;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D oncollision)
    {
        if (oncollision.gameObject.CompareTag("Ground"))
        {
            isgrounded = true;
        }


        if (oncollision.gameObject.CompareTag("EndDevice"))
        {
            gameManagement.RestartGame();
        }

    }

    private void OnCollisionExit2D(Collision2D offcollision)
    {
        if (offcollision.gameObject.CompareTag("Ground"))
            isgrounded = false;
    }
}
