using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SlowingTurret : InteractableObject
{
    public GameObject targetGO = null;
    private GameObject BIGGeneratorGO;

    public float radius = 50;
    public float slowingTimer = 0f;
    public float workingTime = 10.2f;
    public float workingTimer = 0f;
    public float overHeatedTime = 5f;
    public bool overHeated = false;
    public bool destroyed = true;

    public bool outOfPower = false;

    public override void Interact()
    {
        Repair();
    }

    // Update is called once per frame
    void Update()
    {
        //outOfPower = IsGeneratorOutOfPower();
        if (!(outOfPower && !destroyed))
        {
            slowingTimer += Time.deltaTime;
        }
        if (!outOfPower || outOfPower && overHeated)
        {
            workingTimer += Time.deltaTime;
        }
        if (!destroyed)
        {
            if (workingTimer < workingTime)
            {
                Collider[] cols = Physics.OverlapSphere(transform.position, radius);
                foreach (Collider col in cols)
                {
                    if (col && col.tag == "Enemy")
                    {
                        EnemyMovement script = col.GetComponent<EnemyMovement>();
                        script.SlowDownPls();
                    }
                }
            }
            else
            {
                destroyed = true;
                overHeated = true;
                workingTimer = 0f;
                targetGO = null;
            }
        }
        else if (overHeated)
        {
            if (workingTimer > overHeatedTime)
            {
                overHeated = false;
                slowingTimer = 0f;
            }
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
            slowingTimer = float.MaxValue;
            workingTimer = 0f;
        }
    }
}
