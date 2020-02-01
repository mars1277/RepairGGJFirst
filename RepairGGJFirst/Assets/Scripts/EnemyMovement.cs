using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject BIGGeneratorGO;
   // public GameObject cameraGO;
    public float speed = 5f;
    public Vector3 destination;

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        BIGGeneratorGO = GameObject.Find("BIGGenerator");
        agent = transform.parent.gameObject.GetComponent<NavMeshAgent>();
        agent.SetDestination(BIGGeneratorGO.transform.GetChild(0).transform.position);
       // cameraGO = GameObject.Find("Camera");
    }

    // Update is called once per frame
    void Update()
    {
        destination = BIGGeneratorGO.GetComponent<WhoIsTheTarget>().newTarget.transform.position;
        agent.SetDestination(destination);
        //  transform.position += speed * Time.deltaTime * Vector3.Normalize(BIGGeneratorGO.transform.position - transform.position);
        if ((destination - transform.position).x <= 0)
        {
           transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(new Vector3(60, 0, 0));
        }
        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
            transform.Rotate(new Vector3(-60, 180, 0));
        }
      //  transform.rotation = Quaternion.LookRotation(cameraGO.transform.position - transform.position, transform.up);
    }
}
