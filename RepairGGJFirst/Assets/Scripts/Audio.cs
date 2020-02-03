using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour
{
    public AudioClip otherClip;
    AudioSource audioSource;

    public AudioClip[] kickSounds;
    public AudioClip[] laserSounds;

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

    public void PlayKickSound()
    {
        int num = Random.Range(0, kickSounds.Length);
        transform.GetChild(0).GetComponent<AudioSource>().clip = kickSounds[num];
        transform.GetChild(0).GetComponent<AudioSource>().Play();
    }

    public void PlayLaserSound()
    {
        int num = Random.Range(0, laserSounds.Length);
        transform.GetChild(1).GetComponent<AudioSource>().clip = laserSounds[num];
        transform.GetChild(1).GetComponent<AudioSource>().Play();
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
