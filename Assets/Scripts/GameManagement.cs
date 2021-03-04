using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 PlatformStartPoint;

    public PlayerMovement thePlayer;
    private Vector3 PlayerStartPoint;

    // Start is called before the first frame update
    void Start()
    {
        PlatformStartPoint = platformGenerator.position;
        PlayerStartPoint = thePlayer.transform.position;
    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCoroutine");
    }

    public IEnumerator RestartGameCoroutine()
    {
        thePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        thePlayer.transform.position = PlayerStartPoint;
        platformGenerator.position = PlatformStartPoint;
        thePlayer.gameObject.SetActive(true);
    }

}

