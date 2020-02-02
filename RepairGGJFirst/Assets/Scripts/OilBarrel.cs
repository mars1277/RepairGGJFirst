using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class OilBarrel : InteractableObject
{

    public float OilLevel = 10;
    public bool Inserted = false;
    public bool OnHold = false;

    public GameObject Fuelized;
    


    void Start()
    {
        
    }

    void Update()
    {
        if (Inserted == false)
        {
            return;
        }

            if (OilLevel > 0)
        {
            OilLevel = OilLevel - 1 * Time.deltaTime;
            Debug.Log("decrease level");
        }

        if(OilLevel <= 0)
        {
            Debug.Log("destroy");
            Destroy(gameObject);
        }
    }

    public override void Interact()
    {
        Debug.Log(Inserted + " , " + OnHold);
        if (!Inserted)
        {
            if (OnHold)
            {
                transform.SetParent(null);
                OnHold = false;
                if (!BigGenerator.Instance.CurrentBarrel && Vector3.Distance(PlayerMovement.Instance.transform.position, BigGenerator.Instance.transform.position) < PlayerMovement.Instance.maximumInteractionDistance)
                {
                    transform.SetParent(BigGenerator.Instance.transform);
                    Inserted = true; 
                   // this.transform.position = new Vector3(-5.58f, 0.15f, 0.35f);
                    this.transform.position = new Vector3(-5.58f + 0.189f, 0.15f, 0.35f);
                    BigGenerator.Instance.CurrentBarrel = this;
                    Barrel_spawn.Instance.SpawnBarrel();
                }
            }
            else
            {
                transform.SetParent(PlayerMovement.Instance.holder);
                OnHold = true;
            }
        }
    }
}
