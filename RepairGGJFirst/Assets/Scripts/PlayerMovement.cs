using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    private float sqrtTwo = 0.70710678f;

    void Start()
    {

    }

    void Update()
    {
        bool usingTwoKeyToMove = false;
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(speed * Time.deltaTime * sqrtTwo, 0, speed * Time.deltaTime * sqrtTwo);
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(speed * Time.deltaTime * sqrtTwo, 0, -speed * Time.deltaTime * sqrtTwo);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(-speed * Time.deltaTime * sqrtTwo, 0, speed * Time.deltaTime * sqrtTwo);
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            usingTwoKeyToMove = true;
            transform.position += new Vector3(-speed * Time.deltaTime * sqrtTwo, 0, -speed * Time.deltaTime * sqrtTwo);
        }
        if (!usingTwoKeyToMove)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                transform.position += new Vector3(0, 0, -speed * Time.deltaTime);
            }
        }
    }
}
