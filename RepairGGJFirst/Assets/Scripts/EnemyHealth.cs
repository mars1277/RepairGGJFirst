using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if ("Bullet".Equals(collision.tag))
        {
            health--;
            Destroy(collision);
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
