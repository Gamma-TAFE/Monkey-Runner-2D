using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float speedBoost = 5f;
    public float jumpBoost = 3f;
    public float boostTime = 5f;

    void OnTriggerEnter2D(Collider2D collision)
    {
        #region Speed
        if (gameObject.CompareTag("Speed"))                                             //Only activates for objects with Speed Tag
        {
            collision.gameObject.GetComponent<PlayerMovement>().speed += speedBoost;    //Finds float "speed" from player script and adds speed boost
            gameObject.GetComponent<SpriteRenderer>().enabled = false;                  //Disables Sprite
            gameObject.GetComponent<Collider2D>().enabled = false;                      //Disables Collider
            StartCoroutine(SpeedReset());                                               //Starts timer for boost
        }

        IEnumerator SpeedReset()
        {
            yield return new WaitForSeconds(boostTime);                                 //Waits for "boostTime" before stopping the boost
            collision.gameObject.GetComponent<PlayerMovement>().speed -= speedBoost;    //Removes boost
            Destroy(gameObject);                                                        //Destroys Pickup
        }
        #endregion

        #region Jump
        if (gameObject.CompareTag("Jump"))                                              
        {
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce += jumpBoost; 
            gameObject.GetComponent<SpriteRenderer>().enabled = false;                  
            gameObject.GetComponent<Collider2D>().enabled = false;                      
            StartCoroutine(JumpReset());                                                
        }

        IEnumerator JumpReset()
        {
            yield return new WaitForSeconds(boostTime);                                 
            collision.gameObject.GetComponent<PlayerMovement>().jumpForce -= jumpBoost; 
            Destroy(gameObject);                                                        
        }
        #endregion

        #region Invincible
        /*
        if (gameObject.CompareTag("Invincible"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().canDie = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            StartCoroutine(InvincibleReset());
        }

        IEnumerator InvincibleReset()
        {
            yield return new WaitForSeconds(boostTime);
            collision.gameObject.GetComponent<PlayerMovement>().canDie = true;
            Destroy(gameObject);
        }
        */
        #endregion

        #region Coin
        /*
        if (gameObject.CompareTag("Coin"))
        {
            gameObject.GetComponent<Coins>().coinCounter += 1;
            gameObject.GetComponent<Coins>().UpdateCoinText();
            Destroy(gameObject);
        }
        */
        #endregion
    }
}