using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{

    public static CanvasManager Instance;
    public GameObject barrelFeedback;

    void Awake()
    {
        Instance = this;
    }

    public void ShowBarrelFeedback()
    {
        StartCoroutine(DelayIE());
    }

    IEnumerator DelayIE()
    {
        barrelFeedback.SetActive(true);
        yield return new WaitForSeconds(1f);
        barrelFeedback.SetActive(false);

    }
}
