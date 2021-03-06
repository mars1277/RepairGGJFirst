﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MachineHealth : MonoBehaviour
{
    public int health = 3000;
    public int maxHealth = 3000;

    public void DealDamage()
    {
        health--;
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver" +
            "" +
            "", LoadSceneMode.Single);
        }
    }

    public void DealDamage(int dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver" +
            "" +
            "", LoadSceneMode.Single);
        }
    }
}
