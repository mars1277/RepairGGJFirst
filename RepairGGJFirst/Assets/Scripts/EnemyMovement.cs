using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject BIGGeneratorGO;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        BIGGeneratorGO = GameObject.Find("BIGGenerator");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.Normalize(BIGGeneratorGO.transform.position - transform.position);
        if((BIGGeneratorGO.transform.position - transform.position).x <= 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(new Vector3(60, 0, 0));
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(new Vector3(-60, 180, 0));
        }
    }
}
