using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoIsTheTarget : MonoBehaviour
{
    public GameObject newTarget = null;

    private void Start()
    {
        newTarget = gameObject;
    }
}
