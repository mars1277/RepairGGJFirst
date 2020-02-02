using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void MainMenu()
    {
        //Destroy(GameObject.Find("MusicManager"));
        SceneManager.LoadScene("MainMenu");
    }

    public void Play()
    {
        SceneManager.LoadScene("Adam");
    }
}
