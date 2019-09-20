using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource : MonoBehaviour
{
    AudioSource audioSource;


    void Start()
    {
        
    }
    public void PlayOneShot(AudioClip clip)
    {
        if(audioSource != null)
        {
            audioSource.PlayOneShot(clip);

        }
    }
    
        
    
   
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioSource>();
            Debug.Log("fis");
        }
    }
}
