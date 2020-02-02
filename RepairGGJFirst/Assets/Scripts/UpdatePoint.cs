using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("points");
    }
}
