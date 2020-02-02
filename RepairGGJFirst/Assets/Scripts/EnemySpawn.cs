using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour

{
    public int minEnemyNumber = 3;
    public int maxEnemyNumber = 5;
    public Transform[] enemySpawnPoints = new Transform[10];
    public GameObject[] items = new GameObject[1];


    public static EnemySpawn Instance;

    public int currentEnemyNumber;

    void Start()
    {
        currentEnemyNumber = Random.Range(minEnemyNumber, maxEnemyNumber + 1);

        for (int i = 0; i < currentEnemyNumber; i++)
        {
            SpawnEnemy();
            Debug.Log("First Wave");
        }
        Debug.Log("firstenemy " + currentEnemyNumber);

        minEnemyNumber++;
        maxEnemyNumber++;

        Instance = this;
    }

    public void CheckEndWave()
    {
        if(currentEnemyNumber <= 0)
        {
            currentEnemyNumber = Random.Range(minEnemyNumber, maxEnemyNumber + 1);
            Debug.Log("new wave");
            for (int i = 0; i < currentEnemyNumber; i++)
            {
                SpawnEnemy();
            }
            minEnemyNumber++;
            maxEnemyNumber++;
        }
        
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
