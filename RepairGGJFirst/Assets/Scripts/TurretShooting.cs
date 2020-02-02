using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretShooting : InteractableObject
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

    public override void Interact()
    {
        Repair();
    }

    // Update is called once per frame
    void Update()
    {
        if (BIGGeneratorGO.GetComponent<BigGenerator>().CurrentBarrel == null)
        {
            outOfPower = true;
        }
        else
        {
            outOfPower = false;
        }
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
                if (targetGO == null)
                {
                    targetGO = FindNearestEnemy();
                }
                if (targetGO != null && bulletTimer > bulletCD && !outOfPower)
                {
                    GameObject bullet = Instantiate(bulletGOPrefab, transform);
                    Vector3 direction = new Vector3(targetGO.transform.position.x - transform.position.x, 0, targetGO.transform.position.z - transform.position.z);
                    float z = Mathf.Sqrt(Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2));
                    GameObject tmpGO = new GameObject();
                    // float rotation = 90 - 180 / Mathf.PI * Mathf.Cos(direction.y / z) / Mathf.Sin(direction.x / z);
                    /*float rotation = 180 / Mathf.PI * Mathf.Sin(direction.x / z);
                    tmpGO.transform.Rotate(0, 0, rotation);*/
                    bullet.transform.localScale = new Vector3(bullet.transform.localScale.x / transform.localScale.x, bullet.transform.localScale.y / transform.localScale.y, bullet.transform.localScale.z / transform.localScale.z);
                    bullet.GetComponent<BulletMovement>().setRotationAndDirection(tmpGO.transform.rotation, Vector3.Normalize(direction));
                    Destroy(tmpGO);
                    bulletTimer = 0f;
                }
                if (targetGO != null && Mathf.Sqrt(Mathf.Pow((transform.position.x - targetGO.transform.position.x), 2) + Mathf.Pow((transform.position.y - targetGO.transform.position.y), 2)) > range)
                {
                    targetGO = null;
                }
            } else
            {
                destroyed = true;
                overHeated = true;
                workingTimer = 0f;
                targetGO = null;
            }
        } else if(overHeated)
        {
            if(workingTimer > overHeatedTime)
            {
                overHeated = false;
                bulletTimer = 0f;
                targetGO = null;
            }
        }
        
        if (Input.GetKey(KeyCode.F))
        {
            outOfPower = !outOfPower;
        }
    }

    GameObject FindNearestEnemy()
    {
        //var e = EnemyHealth.instances.Where(x => Vector3.Distance(transform.position, x.transform.position) < range).OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float minDistance = float.MaxValue;
        GameObject nearestEnemy = null;
        if (enemies.Length > 0)
        {
            // Debug.Log(enemies[0]);
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            float distance = Mathf.Sqrt(Mathf.Pow((transform.position.x - enemies[i].transform.position.x), 2) + Mathf.Pow((transform.position.y - enemies[i].transform.position.y), 2));
            //Debug.Log(distance);
            if (distance < minDistance)
            {
                minDistance = distance;
                if (minDistance <= range)
                {
                    nearestEnemy = enemies[i];
                }
            }
        }
        return nearestEnemy;
    }

    float CalculateBulletRotation (GameObject enemy)
    {
        Vector3 up = new Vector3(0, playerGO.transform.localEulerAngles.y, 0);
        return 0f;
    }

    public void Repair()
    {
        if (!overHeated && destroyed)
        {
            destroyed = false;
            bulletTimer = float.MaxValue;
            workingTimer = 0f;
        }
    }
}
