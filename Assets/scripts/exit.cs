using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class exit : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonSE;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void exitbuttonOnClick()
    {
        audioSource.PlayOneShot(buttonSE);
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
  Application.Quit();
#endif
    }
}