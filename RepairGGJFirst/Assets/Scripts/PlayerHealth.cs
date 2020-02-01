using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 50;

    void Update()
    {
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        if ("Enemy".Equals(collision.tag))
        {
            Damage();
        }
    }

    public void Damage()
    {
        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene("Lose", LoadSceneMode.Single);
        }
    }
}
