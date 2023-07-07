using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public Transform player;
    public float levelWidth = 10f;
    public float levelLength = 20f;
    public int levelsOnScreen = 5;
    public float moveSpeed = 5f;

    private List<GameObject> activeLevels = new List<GameObject>();
    private float spawnZ = 0f;

    private void Start()
    {
        for (int i = 0; i < levelsOnScreen; i++)
        {
            SpawnLevel();
        }
    }

    private void Update()
    {
        float playerMoveDistance = moveSpeed * Time.deltaTime;
        transform.position += Vector3.back * playerMoveDistance;

        if (player.position.z - levelLength > spawnZ - levelsOnScreen * levelLength)
        {
            SpawnLevel();
            DeleteLevel();
        }
    }

    private void SpawnLevel()
    {
        GameObject level = Instantiate(levelPrefabs[Random.Range(0, levelPrefabs.Length)], new Vector3(0f, 0f, spawnZ), Quaternion.identity);
        activeLevels.Add(level);
        spawnZ += levelLength;
    }

    private void DeleteLevel()
    {
        Destroy(activeLevels[0]);
        activeLevels.RemoveAt(0);
    }
}
