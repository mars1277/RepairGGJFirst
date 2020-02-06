using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarMover2000 : MonoBehaviour
{
    public bool isTurret = false;
    public bool isShootingTurret = false;
    public bool isSlowingTurret = false;
    public bool isWallTurret = false;
    public bool isBigGenerator = false;

    GameObject turretBar;
    float maxWidth;

    TurretShooting turretShooting;
    SlowingTurret slowingTurret;
    WallTurret wallTurret;

    MachineHealth machineHealth;


    // Start is called before the first frame update
    void Start()
    {
        if (isBigGenerator)
        {
            maxWidth = transform.localScale.y;
            machineHealth = transform.parent.transform.parent.transform.parent.GetComponent<MachineHealth>();
        }
        if (isTurret)
        {
            maxWidth = transform.localScale.y;
            if (isShootingTurret)
            {
                turretShooting = transform.parent.transform.parent.GetComponent<TurretShooting>();
            }
            if (isSlowingTurret)
            {
                slowingTurret = transform.parent.transform.parent.GetComponent<SlowingTurret>();
            }
            if (isWallTurret)
            {
                wallTurret = transform.parent.transform.parent.GetComponent<WallTurret>();
            }
            transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(211f / 256f, 40f / 256f, 42f / 256f);
            transform.localScale = new Vector3(transform.localScale.x, 0, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isBigGenerator)
        {
            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (1f - machineHealth.health / machineHealth.maxHealth), transform.localScale.z);
        }
        if (isTurret)
        {
            if (isShootingTurret)
            {
                if (!turretShooting.destroyed || turretShooting.destroyed && turretShooting.overHeated)
                {
                    if (turretShooting.overHeated || turretShooting.outOfPower)
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(211f / 256f, 40f / 256f, 42f / 256f);
                        if (turretShooting.overHeated)
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (1f - turretShooting.workingTimer / turretShooting.overHeatedTime), transform.localScale.z);
                        } else
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (turretShooting.workingTimer / turretShooting.workingTime), transform.localScale.z);
                        }
                    }
                    else
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(11f / 256f, 225f / 256f, 238f / 256f);
                        transform.localScale = new Vector3(transform.localScale.x, maxWidth * (turretShooting.workingTimer / turretShooting.workingTime), transform.localScale.z);
                    }
                }
            }
            if (isSlowingTurret)
            {
                if (!slowingTurret.destroyed || slowingTurret.destroyed && slowingTurret.overHeated)
                {
                    if (slowingTurret.overHeated || slowingTurret.outOfPower)
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(211f / 256f, 40f / 256f, 42f / 256f);
                        if (slowingTurret.overHeated)
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (1f - slowingTurret.workingTimer / slowingTurret.overHeatedTime), transform.localScale.z);
                        }
                        else
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (slowingTurret.workingTimer / slowingTurret.workingTime), transform.localScale.z);
                        }
                    }
                    else
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(11f / 256f, 225f / 256f, 238f / 256f);
                        transform.localScale = new Vector3(transform.localScale.x, maxWidth * (slowingTurret.workingTimer / slowingTurret.workingTime), transform.localScale.z);
                    }
                }
            }
            if (isWallTurret)
            {
                if (!wallTurret.destroyed || wallTurret.destroyed && wallTurret.overHeated)
                {
                    if (wallTurret.overHeated || wallTurret.outOfPower)
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(211f / 256f, 40f / 256f, 42f / 256f);
                        if (wallTurret.overHeated)
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (1f - wallTurret.workingTimer / wallTurret.overHeatedTime), transform.localScale.z);
                        }
                        else
                        {
                            transform.localScale = new Vector3(transform.localScale.x, maxWidth * (wallTurret.workingTimer / wallTurret.workingTime), transform.localScale.z);
                        }
                    }
                    else
                    {
                        transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(11f / 256f, 225f / 256f, 238f / 256f);
                        transform.localScale = new Vector3(transform.localScale.x, maxWidth * (wallTurret.workingTimer / wallTurret.workingTime), transform.localScale.z);
                    }
                }
            }
        }
    }
}
