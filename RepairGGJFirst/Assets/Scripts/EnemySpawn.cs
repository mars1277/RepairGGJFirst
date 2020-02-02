using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour

{

    public Transform[] enemySpawnPoints = new Transform[10];
    public GameObject[] items = new GameObject[1];
    public int minEnemyNumber = 1;
    public int maxEnemyNumber = 1;
    int currentEnemyNumber;

    void Start()
    {
       currentEnemyNumber = Random.Range(minEnemyNumber, maxEnemyNumber);

        for (int i = 0; i < currentEnemyNumber; i++)
        {
            SpawnEnemy();
        }

       minEnemyNumber++;
       maxEnemyNumber++;
       Debug.Log(minEnemyNumber + maxEnemyNumber);
    }

    public void FixedUpdate()
    {
        
    }

    public Transform GetEnemySpawnPoint()
    {
        int index = Random.Range(0, enemySpawnPoints.Length);
        return enemySpawnPoints[index];
    }

    //selects object to spawn
    public GameObject GetEnemy()
    {
        int index = Random.Range(0, items.Length);
        return items[index];
    }

    // spawns the random object on the random point
    public GameObject SpawnEnemy()
    {
        Transform spawnPoint = GetEnemySpawnPoint();
        GameObject enemy = GetEnemy();
        GameObject c = Instantiate(enemy, spawnPoint.position, spawnPoint.rotation) as GameObject;
        return c;
    }
}
