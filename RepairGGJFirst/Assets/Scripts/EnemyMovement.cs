using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject BIGGeneratorGO;
   // public GameObject cameraGO;
    public float normalspeed = 2.5f;
    public float speed;
    public Vector3 destination;

    public NavMeshAgent agent;

    public float kickPower = 0.004f;

    // Start is called before the first frame update
    void Start()
    {
        speed = normalspeed;
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
    
    public void KickedBack()
    {
        Debug.Log("kicked");
        StartCoroutine(KickBack());
    }

    private IEnumerator KickBack()
    {
        transform.parent.GetComponent<NavMeshAgent>().enabled = false;
        int fallTimer = 0;
        int fallTime = 30;
        float step = 0.01f;
        while (fallTimer < fallTime)
        {
            fallTimer++;
            Debug.Log(new Vector3(1, 0, 0) / fallTime * kickPower * Mathf.Pow(fallTimer, 2));
            transform.parent.transform.position += Vector3.Normalize(transform.parent.transform.position - GameObject.Find("Player").transform.position) / fallTime * kickPower * Mathf.Pow((fallTimer + 1), 2);
            yield return new WaitForSeconds(step);
        }
        transform.parent.GetComponent<NavMeshAgent>().enabled = true;
    }

    public void SlowDownPls()
    {
        speed = normalspeed * 0.7f;
        Debug.Log("decreased speed" + normalspeed);
    }
}
