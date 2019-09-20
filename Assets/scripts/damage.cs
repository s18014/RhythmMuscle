using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class damage : MonoBehaviour
{
    public int MP;
   
    public readonly int maxMP = 100;

    void Start()
    {
        MP = maxMP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(MP > 0)
        {
            this.gameObject.SetActive(false);

            Invoke("gameover", 0.5f);
        }
    }
    void gameover()
    {
        SceneManager.LoadScene("over");
    }
    void Update()
    {
        
        
    }
    
}
