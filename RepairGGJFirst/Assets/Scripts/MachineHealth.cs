using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineHealth : MonoBehaviour
{
    public int health = 10;

    public void DealDamage()
    {
        health--;
    }

    public void DealDamage(int dmg)
    {
        health -= dmg;
    }
}
