﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitleScene()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadBattleScene()
    {
        SceneManager.LoadScene("Battle");
    }

    public void LoadOverScene()
    {
        SceneManager.LoadScene("over");
    }

    public void LoadClearScene()
    {
        SceneManager.LoadScene("clear");
    }
}
