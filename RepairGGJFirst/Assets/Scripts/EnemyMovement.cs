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
    }
}
