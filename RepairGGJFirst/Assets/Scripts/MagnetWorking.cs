using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetWorking : MonoBehaviour
{
    public GameObject targetGO = null;
    public GameObject bulletGOPrefab;
    private GameObject BIGGeneratorGO;
    private GameObject playerGO;
    public float bulletTimer = 0f;
    public float bulletCD = 1f;
    public float range = 2f;

    public float workingTime = 10.2f;
    public float workingTimer = 0f;
    public float overHeatedTime = 5f;
    public bool overHeated = false;
    public bool destroyed = true;

    public bool outOfPower = false;

    // Start is called before the first frame update
    void Start()
    {
        BIGGeneratorGO = GameObject.Find("BIGGenerator");
        playerGO = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //outOfPower = IsGeneratorOutOfPower();
        if (!(outOfPower && !destroyed))
        {
            bulletTimer += Time.deltaTime;
        }
        if (!outOfPower || outOfPower && overHeated)
        {
            workingTimer += Time.deltaTime;
        }
        if (!destroyed)
        {
            if (workingTimer < workingTime)
            {
                BIGGeneratorGO.GetComponent<WhoIsTheTarget>().newTarget = gameObject;
            }
            else
            {
                destroyed = true;
                overHeated = true;
                workingTimer = 0f;
                targetGO = null;
                BIGGeneratorGO.GetComponent<WhoIsTheTarget>().newTarget = BIGGeneratorGO;
            }
        }
        else if (overHeated)
        {
            if (workingTimer > overHeatedTime)
            {
                overHeated = false;
                bulletTimer = 0f;
                targetGO = null;
            }
            BIGGeneratorGO.GetComponent<WhoIsTheTarget>().newTarget = BIGGeneratorGO;
        }
        if (Input.GetKey(KeyCode.R))
        {
            Repair();
        }
        if (Input.GetKey(KeyCode.F))
        {
            outOfPower = !outOfPower;
        }
    }

    public void Repair()
    {
        if (!overHeated && destroyed)
        {
            destroyed = false;
            bulletTimer = float.MaxValue;
            workingTimer = 0f;
            BIGGeneratorGO.GetComponent<WhoIsTheTarget>().newTarget = gameObject;
        }
    }
}
