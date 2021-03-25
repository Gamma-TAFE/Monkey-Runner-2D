using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // SerializeField makes a private var accessable in Unity (eg. We have the same access as if we said - public GameObject player; -)
    public const float distanceBetweenPlatforms = 30f;
    public const float playerToLastPlat = 50f;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    private Vector3 lastEndPosition;


   private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;

        int startingSpawnLevelParts = 1;
        for (int i = 0; i < startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
        

    }

    // Spawns more level parts if player gets too close to the lastEndPosition
    private void Update()
    {
        if (Vector3.Distance(player.transform.position, lastEndPosition) < playerToLastPlat)
        {
            SpawnLevelPart();
        }
    }


    // Spawns a level part and locates where the EndPosition of said spawned part is
    void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;

    }

    Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }


}