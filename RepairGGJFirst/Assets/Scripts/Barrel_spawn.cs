using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel_spawn : MonoBehaviour

{

    public Transform[] barrelSpawnPoints = new Transform[10];
    public GameObject[] items = new GameObject[1];

    public float OilLevel = 1000;
    public float ConsumeTime = 1.0f;

    void Start()
    {
        SpawnBarrel();
        StartCoroutine(OilConsumer());
    }

    public IEnumerator OilConsumer()
    {
        while (OilLevel > 0)
        {
            Debug.Log("Before Waiting 2 seconds");
            yield return new WaitForSeconds(ConsumeTime);
            OilLevel = OilLevel - 1;
            Debug.Log("After Waiting 2 Seconds");
        }
        
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
