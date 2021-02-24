using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Player;
    private float offset;
    

     void Start()
     {
        offset = transform.position.x - Player.transform.position.x;    
     }

    void LateUpdate()
    {
        transform.position = new Vector3(Player.transform.position.x + offset, transform.position.y, transform.position.z);
    }

}
