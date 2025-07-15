using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    public GroundSpawner groundSpawner;
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public Transform[] spawnPoints;

    private void Awake()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            groundSpawner.spawnTile();
           
            Destroy(gameObject, 2f);
        }
    }

    public void SpawnObs()
    {
        int chooseSpawnPoint = Random.Range(0, spawnPoints.Length);
        int SpawnPrefab = Random.Range(0, obstaclePrefabs.Length);

        Instantiate(obstaclePrefabs[SpawnPrefab], spawnPoints[chooseSpawnPoint].transform.position, Quaternion.identity, transform);
    }

    public void Start()
    {
        SpawnObs();
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        int spawnAmount = 1;
        for (int i = 0; i < spawnAmount; i++)
        {
            GameObject coin = Instantiate(coinPrefab, transform);
            coin.transform.position = spawnrandomPoint(GetComponent<Collider>());

        }
    }

    Vector3 spawnrandomPoint(Collider col)
    {
        Vector3 randomPoint = new Vector3(Random.Range(col.bounds.min.x, col.bounds.max.x),
                                          Random.Range(col.bounds.min.y, col.bounds.max.y),
                                          Random.Range(col.bounds.min.z, col.bounds.max.z));
        randomPoint.y = 1;
        return randomPoint;
    }
}
