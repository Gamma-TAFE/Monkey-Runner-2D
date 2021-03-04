using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // pdslp = Player Distance Spawn Level Part
    private const float pdslp = 20f;

    // SerializeField allows us to allocate a position to this variable even though its marked as Private

    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private GameObject player;


    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        int startingSpawnLevelParts = 5;
        for (int i = 0; i <= startingSpawnLevelParts; i++)
        {
            SpawnLevelPart();
        }
    }


    // Spawns more level parts if player gets too close to the lastEndPosition
    private void Update()
    {
        if(Vector3.Distance(player.transform.position, lastEndPosition) < pdslp)
        {
            SpawnLevelPart();
        }

    }

    // Spawns a level part and locates where the EndPosition of said spawned part is
    private void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }


}
