using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    public static List<EnemyHealth> instances = new List<EnemyHealth>();

    private void OnEnable()
    {
        instances.Add(this);
    }

    private void OnDisable()
    {
        instances.Remove(this);
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if ("Bullet".Equals(collision.tag))
        {
            health--;
            Destroy(collision);
            if (health <= 0)
            {
                {
                    EnemySpawn.Instance.currentEnemyNumber--;
                    Debug.Log(EnemySpawn.Instance.currentEnemyNumber);
                    Destroy(transform.parent.gameObject);
                    Destroy(gameObject);
                    
                }
            }
        }

        if ("EnemyTarget".Equals(collision.tag))
        {
            EnemySpawn.Instance.currentEnemyNumber--;
            Debug.Log(EnemySpawn.Instance.currentEnemyNumber);
            Debug.Log("collided");
            collision.gameObject.GetComponent<MachineHealth>().DealDamage();
            Destroy(transform.parent.gameObject);
            Destroy(gameObject);
        }
    }
}

