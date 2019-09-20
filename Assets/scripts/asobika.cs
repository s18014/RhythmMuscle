using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class asobika : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip buttonSE;
    private void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }
    public void OnAsobikataButtonClicked()
    {
        audioSource.PlayOneShot(buttonSE);
        Invoke("loadscene", 1);
    }
    public void loadscene()
    {
        SceneManager.LoadScene("asobika"); //シーン切り替え
    }
    
}
