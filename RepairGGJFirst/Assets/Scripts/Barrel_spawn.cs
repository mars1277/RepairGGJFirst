using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_spawn : MonoBehaviour

{

    public Transform[] barrelSpawnPoints = new Transform[10];
    public GameObject[] items = new GameObject[1];

    void Start()
    {
        SpawnBarrel();
    }

    public Transform GetBarrelSpawnPoint()
    {
        int index = Random.Range(0, barrelSpawnPoints.Length);
        return barrelSpawnPoints[index];
    }

    //selects object to spawn
    public GameObject GetBarrel()
    {
        int index = Random.Range(0, items.Length);
        return items[index];
    }

    // spawns the random object on the random point
    public GameObject SpawnBarrel()
    {
        Transform spawnPoint = GetBarrelSpawnPoint();
        GameObject barrel = GetBarrel();
        GameObject c = Instantiate(barrel, spawnPoint.position, spawnPoint.rotation) as GameObject;
        return c;
    }
}
