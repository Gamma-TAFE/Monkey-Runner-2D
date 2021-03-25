using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenTest : MonoBehaviour
{
    //Public Vars

    public GameObject Player;
    public GameObject startingPlatform;
    //public GameObject levelPart1;
    public List<GameObject> levelParts;

    //Private Vars

    //Positions of important things
    private Vector3 playerPosition;
    private GameObject chosenLevelPart;
    private Vector3 nextSpawn;
    private Vector3 lastEndPos;

    //private bool spawned = false;

    private readonly float distanceToLastEndPos = 200f;

    //SerializeField Vars

    void Awake()
    {
        nextSpawn = startingPlatform.transform.Find("nextSP").position;
        lastEndPos = startingPlatform.transform.Find("EndPosition").position;

        int startingSpawnLevelParts = 5;
        for(int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }

    void Update()
    {
        playerPosition = Player.transform.position;
        
        // Spawns a Part if player gets too close to the end
        if (Vector3.Distance(playerPosition, lastEndPos) <= distanceToLastEndPos)
        {
            SpawnLevelPart();
        }
    }
    void SpawnLevelPart()
    {
        // Level Stuff
        chosenLevelPart = levelParts[Random.Range(0, levelParts.Count)];
        GameObject spawnedPart = Instantiate(chosenLevelPart);
        spawnedPart.transform.position = new Vector3(nextSpawn.x +5f, nextSpawn.y, nextSpawn.z);
        nextSpawn = spawnedPart.transform.Find("nextSP").position;
        lastEndPos = spawnedPart.transform.Find("EndPosition").position;


    }

    // 3.05f 0.32f and 0.0f
}
