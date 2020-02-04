using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTurret : InteractableObject
{
    private GameObject BIGGeneratorGO;
    private GameObject playerGO;
    public float range = 2f;
    public Sprite goodSprite;
    public Sprite redSprite;


    public float workingTime = 10.2f;
    public float workingTimer = 0f;
    public float overHeatedTime = 5f;
    public bool overHeated = false;
    public bool destroyed = true;

    public bool outOfPower = false;

    public bool upStarted = false;
    public bool isWallUp = false;

    public GameObject wallGO;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = redSprite;
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
            if (isWallUp)
            {
                StartCoroutine(moveWall(false));
                isWallUp = false;
            }
        }
        else
        {
            outOfPower = false;
            if (!isWallUp && !destroyed)
            {
                StartCoroutine(moveWall(true));
                isWallUp = true;
            }
        }
        if (!outOfPower || outOfPower && overHeated)
        {
            workingTimer += Time.deltaTime;
        }
        if (!destroyed)
        {
            if (workingTimer < workingTime)
            {
                if (!upStarted)
                {
                    if (!isWallUp)
                    {
                        StartCoroutine(moveWall(true));
                        isWallUp = true;
                    }
                    upStarted = true;
                }
            }
            else
            {
                destroyed = true;
                overHeated = true;
                workingTimer = 0f;
                upStarted = false;
                if (isWallUp)
                {
                    StartCoroutine(moveWall(false));
                    isWallUp = false;
                }
            }
        }
        else if (overHeated)
        {
            if (workingTimer > overHeatedTime)
            {
                overHeated = false;
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
            workingTimer = 0f;
            this.GetComponent<SpriteRenderer>().sprite = goodSprite;
        }
    }

    public IEnumerator moveWall(bool up)
    {
        int steps = 60;
        int stepCounter = 0;
        while (stepCounter < steps)
        {
            wallGO.transform.position += new Vector3(0, (up ? 1 : -1) * 0.02f, 0);
            yield return new WaitForSeconds(0.005f);
            stepCounter++;
        }
    }
}
