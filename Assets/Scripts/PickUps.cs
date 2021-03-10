using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float speedBoost = 5f;
    public float jumpBoost = 3f;
    public float boostTime = 5f;

    public float minIncrease = 5f;
    public float maxIncrease = 10f;
    float increase;


    void Start()
    {
        increase = Random.Range(minIncrease, maxIncrease);
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        


        if (gameObject.CompareTag("Speed"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().speed += speedBoost;    //Finds float "speed" from player script and adds speed boost
            gameObject.GetComponent<SpriteRenderer>().enabled = false;                  //Disables Sprite
            gameObject.GetComponent<Collider2D>().enabled = false;                      //Disables Collider
            StartCoroutine(SpeedReset());                                               //Starts timer for boost
        }

        if (gameObject.CompareTag("Jump"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce += jumpBoost; //Finds float "jumpForce" from player script and adds jump boost
            gameObject.GetComponent<SpriteRenderer>().enabled = false;                  //Disables Sprite
            gameObject.GetComponent<Collider2D>().enabled = false;                      //Disables Collider
            StartCoroutine(JumpReset());                                                //Starts timer for boost
        }

       IEnumerator SpeedReset()
        {
            yield return new WaitForSeconds(boostTime);                                 //Waits for "boostTime" before stopping the boost
            collision.gameObject.GetComponent<PlayerMovement>().speed -= speedBoost;
            Destroy(gameObject);
        }

        IEnumerator JumpReset()
        {
            yield return new WaitForSeconds(boostTime);
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce -= jumpBoost;
            Destroy(gameObject);
        }
    }
}