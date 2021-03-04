using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float speedBoost = 5f;
    public float jumpBoost = 3f;

    public float minIncrease = 5f;
    public float maxIncrease = 10f;
    float increase;

    public float pickUpTime = 10f;
    public float colTime;

    public bool sped;

    void Start()
    {
        increase = Random.Range(minIncrease, maxIncrease);
        sped = false;
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        


        if (gameObject.CompareTag("Speed"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().speed += speedBoost;
            colTime = Time.time;
            sped = true;
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Jump"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce += jumpBoost;
            Destroy(gameObject);
            colTime = Time.time;
        }

       /* if (Time.time == colTime + pickUpTime && sped == true)
        {
            collision.gameObject.GetComponent<PlayerMovement>().speed -= speedBoost;
            sped = false;
        }*/
    }
}