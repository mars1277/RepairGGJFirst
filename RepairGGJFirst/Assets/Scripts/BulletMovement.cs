using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(direction.x * speed * Time.deltaTime, 0, direction.z * speed * Time.deltaTime);
    }

    public void setRotationAndDirection(Quaternion rotation, Vector3 dir)
    {
       // transform.rotation = rotation;
        direction = dir;
    }
}
