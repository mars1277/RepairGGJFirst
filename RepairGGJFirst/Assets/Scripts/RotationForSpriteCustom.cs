using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationForSpriteCustom : MonoBehaviour
{
    float rotationForSpriteCustom;
    public bool rotateBack = false;
    public float plusRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rotationForSpriteCustom = GameObject.Find("Canvas").GetComponent<UltimateRotationForSprites>().ultimateRotation;
        transform.localEulerAngles = new Vector3((rotateBack ? -1 : 1) * rotationForSpriteCustom + plusRotation, 0, 0);
    }
}
