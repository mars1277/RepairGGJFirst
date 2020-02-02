using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roadhouse : MonoBehaviour
{
    public PlayerMovement.Directions direction = PlayerMovement.Directions.RIGHT;
    public float roadhouseTime = 0.3f;
    float roadhouseTimer = 999f;

    //GameObject[] enemies = new GameObject[1000];
    LinkedList<GameObject> enemies = new LinkedList<GameObject>();

    private void Start()
    {
        roadhouseTimer = roadhouseTime * 2;
    }

    void Update()
    {
        roadhouseTimer += Time.deltaTime;
        if (roadhouseTimer > roadhouseTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                foreach(GameObject enemy in enemies)
                {
                    enemy.GetComponent<EnemyMovement>().KickedBack();
                }
            }
            roadhouseTimer = 0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        enemies.AddLast(collision.gameObject);
    }

    private void OnTriggerExit(Collider collision)
    {
        enemies.Remove(collision.gameObject);
    }
}
