using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float speedBoost;
    public float jumpBoost;

    public float minIncrease = 5f;
    public float maxIncrease = 10f;
    float increase;

    void Start()
    {
        increase = Random.Range(minIncrease, maxIncrease);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.CompareTag("Speed"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().speed += speedBoost;
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Jump"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce += jumpBoost;
            Destroy(gameObject);
        }
    }
}
