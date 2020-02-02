using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIHandler : MonoBehaviour
{
    public GameObject playerHealth;
    public GameObject generatorHealth;
    public GameObject points;

    private void Start()
    {
        playerHealth = GameObject.Find("PlayerHealthNum");
        generatorHealth = GameObject.Find("GeneratorHealthNum");
        points = GameObject.Find("PointsNum");
    }

    // Update is called once per frame
    void Update()
    {
        playerHealth.GetComponent<TMPro.TextMeshProUGUI>().text = "" + GameObject.Find("Player").GetComponent<PlayerHealth>().health;
        generatorHealth.GetComponent<TMPro.TextMeshProUGUI>().text = "" + BigGenerator.Instance.gameObject.GetComponent<MachineHealth>().health;
        points.GetComponent<TMPro.TextMeshProUGUI>().text = "" + PlayerPrefs.GetInt("points");
    }
}
