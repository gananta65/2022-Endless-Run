using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;
    private Vector3 nextSpawnPoint;

    public void spawnTile()
    {
        GameObject tempGround = Instantiate(groundTilePrefab, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = tempGround.transform.GetChild(0).transform.position;
    }

    void Start()
    {
        // Spawn beberapa tile awal
        for (int i = 0; i < 10; i++)
        {
            spawnTile();
        }
    }
}
