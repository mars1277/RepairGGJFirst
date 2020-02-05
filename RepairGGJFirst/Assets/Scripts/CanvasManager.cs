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

    public void ShowBarrelFeedback(string Feedback)
    {
        barrelFeedback.GetComponent<TMPro.TextMeshProUGUI>().text = Feedback;
        StartCoroutine(DelayIE());
    }

    IEnumerator DelayIE()
    {
        barrelFeedback.SetActive(true);
        yield return new WaitForSeconds(1f);
        barrelFeedback.SetActive(false);

    }
}
