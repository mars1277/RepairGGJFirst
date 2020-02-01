using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGenerator : InteractableObject
{
    public Transform holder;
    public static BigGenerator Instance;

    public void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

}
