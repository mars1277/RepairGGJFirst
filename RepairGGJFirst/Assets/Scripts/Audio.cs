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

    // Update is called once per frame
    void Update()
    {
        Debug.Log(audioSource.clip);
        if (!audioSource.isPlaying)
        {
            /*audioSource.clip = otherClip;
            audioSource.Play();*/
        }
        
    }
}
