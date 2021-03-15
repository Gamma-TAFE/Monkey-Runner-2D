using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField] private GameObject platformGenerationPoint;
    public float distanceBetweenPlatforms;
    public float playerDistanceBetweenPlatforms;

    // SerializeField allows us to allocate a position to this variable even though its marked as Private

    [SerializeField] private GameObject player;
    [SerializeField] private Transform levelPartStart;
    [SerializeField] private List<Transform> levelPartList;
    private Transform chosenLevelPart;
    private Vector2 lastEndPosition;
    private Vector2 nextStartPosition;
    private Vector2 playerPosition;

    void Awake()
    {
        lastEndPosition = levelPartStart.Find("EndPosition").position;
        nextStartPosition = levelPartStart.Find("StartPosition").position;

    }

    // Spawns more level parts if player gets too close to the lastEndPosition
    void Update()
    {
        playerPosition = player.transform.position;
        if (Vector2.Distance(playerPosition, lastEndPosition) < playerDistanceBetweenPlatforms)
        {
            SpawnLevelPart();
        }

    }

    // Spawns a level part and locates where the EndPosition of said spawned part is
    void SpawnLevelPart()
    {
        chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        Transform nextLevelPartTransform = SpawnLevelPart(chosenLevelPart, nextStartPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        nextStartPosition = nextLevelPartTransform.Find("StartPosition").position;
        if (Vector2.Distance(lastEndPosition, nextStartPosition) < distanceBetweenPlatforms)
        {
            nextStartPosition = new Vector2(nextStartPosition.x + distanceBetweenPlatforms, transform.position.y);
            Debug.Log(nextStartPosition);
        }
    }

    Transform SpawnLevelPart(Transform levelPart, Vector2 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;

    }


}