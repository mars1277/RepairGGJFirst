using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilBarrel : InteractableObject
{

    public float OilLevel = 10;
    public bool Inserted = false;
    public bool OnHold = false;


    void Update()
    {
        if (Inserted == false)
        {
            return;
        }

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

    public override void Interact()
    {
        if (OnHold)
        {
            transform.SetParent(null);
            OnHold = false;
            if(!BigGenerator.Instance.CurrentBarrel && Vector3.Distance(PlayerMovement.Instance.transform.position, BigGenerator.Instance.transform.position) <PlayerMovement.Instance.maximumInteractionDistance)
            {
                transform.SetParent(BigGenerator.Instance.transform);
                Inserted = true;
                BigGenerator.Instance.CurrentBarrel = this;

            }
        }
        else
        {
            transform.SetParent(PlayerMovement.Instance.holder);
            OnHold = true;
        }
    }
}
