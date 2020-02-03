using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Audio");

        if (objs.Length <= 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Update is called once per frame
   /* void Update()
    {
        Debug.Log(audioSource.clip);
        if (!audioSource.isPlaying)
        {
            //audioSource.clip = otherClip;
           // audioSource.Play();
        }
        
    }*/
}
