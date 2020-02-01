using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrel : MonoBehaviour
{

    public float OilLevel = 10;
    public bool Inserted = false;

    void Update()
    {

        if (OilLevel > 0)
        {
            OilLevel = OilLevel - 1 * Time.deltaTime;
        }

        if(OilLevel <= 0)
        {
        Destroy(gameObject);
            Debug.Log("destroy");
        }
    }
}
