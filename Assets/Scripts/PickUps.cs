using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    public float speedBoost =1;
    public float jumpBoost = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
