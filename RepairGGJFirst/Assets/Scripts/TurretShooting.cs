using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShooting : MonoBehaviour
{
    public GameObject targetGO = null;
    public GameObject bulletGOPrefab;
    public float bulletTimer = 0f;
    public float bulletCD = 1f;
    public float range = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bulletTimer += Time.deltaTime;
        if (targetGO == null)
        {
            targetGO = findNearestEnemy();
        }
        if (targetGO != null && bulletTimer > bulletCD)
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
    }

    GameObject findNearestEnemy()
    {
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
}
