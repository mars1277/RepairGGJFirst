using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Roadhouse : MonoBehaviour
{
    public PlayerMovement.Directions direction = PlayerMovement.Directions.RIGHT;
    public float roadhouseTime = 0.3f;
    float roadhouseTimer = 999f;
    public float kickPower = 0.015f;
    public static Roadhouse Instance;


    //GameObject[] enemies = new GameObject[1000];
    LinkedList<GameObject> enemies = new LinkedList<GameObject>();

    private void Start()
    {
        Instance = this;
        roadhouseTimer = roadhouseTime * 2;
    }

    void Update()
    {
        roadhouseTimer += Time.deltaTime;
        if (roadhouseTimer > roadhouseTime)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("kick");
                foreach (GameObject enemy in enemies)
                {
                    if (enemy != null)
                    {
                        enemy.GetComponent<EnemyMovement>().KickedBack(kickPower);
                    }
                }
                roadhouseTimer = 0f;
                GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");
                if (objs.Length == 1)
                {
                    objs[0].GetComponent<Audio>().PlayKickSound();
                }
            }
        }
    }

    public void UpdateCapsule()
    {
        switch (direction)
        {
            case PlayerMovement.Directions.LEFT:
                 gameObject.transform.localPosition = new Vector3(-13, 6, 3);
                 gameObject.transform.localEulerAngles = new Vector3(-60, 0, 90);
                 break;
             case PlayerMovement.Directions.RIGHT:
                 gameObject.transform.localPosition = new Vector3(13, 6, 3);
                 gameObject.transform.localEulerAngles = new Vector3(-60, 0, 90);
                 break;
             case PlayerMovement.Directions.UP:
                 gameObject.transform.localPosition = new Vector3(0, 17, 9.36f);
                 gameObject.transform.localEulerAngles = new Vector3(0, -90, 150);
                 break;
             case PlayerMovement.Directions.DOWN:
                 gameObject.transform.localPosition = new Vector3(0, -7.5f, -4.8f);
                 gameObject.transform.localEulerAngles = new Vector3(0, -90, 150);
                 break;
            case PlayerMovement.Directions.UP_LEFT:
                gameObject.transform.localPosition = new Vector3(-12.2f, 10.3f, 7.3f);
                gameObject.transform.localEulerAngles = new Vector3(-40.93f, 60, 46.2f);
                break;
            case PlayerMovement.Directions.UP_RIGHT:
                gameObject.transform.localPosition = new Vector3(11.5f, 10.5f, 5.6f);
                gameObject.transform.localEulerAngles = new Vector3(-43.16f, -56, 136.95f);
                break;
            case PlayerMovement.Directions.DOWN_LEFT:
                gameObject.transform.localPosition = new Vector3(-10, -3.86f, -2.13f);
                gameObject.transform.localEulerAngles = new Vector3(-43.16f, -56, 136.95f);
                break;
            case PlayerMovement.Directions.DOWN_RIGHT:
                gameObject.transform.localPosition = new Vector3(8.9f, -4.4f, -3.9f);
                gameObject.transform.localEulerAngles = new Vector3(-40.93f, 60, 46.2f);
                break;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if ("Enemy".Equals(collision.tag))
        {
            Debug.Log("added");
            enemies.AddLast(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if ("Enemy".Equals(collision.tag))
        {
            Debug.Log("ended");
            enemies.Remove(collision.gameObject);
        }
    }
}
