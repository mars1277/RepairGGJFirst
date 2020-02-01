using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public static List<InteractableObject> Instances = new List<InteractableObject>();

    public void OnEnable()
    {
        Instances.Add(this);
    }

    public void OnDisable()
    {
        Instances.Remove(this);
    }

    public virtual void Interact()
    {

    }
}
