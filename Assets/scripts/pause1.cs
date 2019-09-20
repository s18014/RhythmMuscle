using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause1 : MonoBehaviour
{
    private bool isStop = false;

    public void Stop()
    {
        isStop = !isStop;
        if (isStop) { Time.timeScale = 0f; } else Time.timeScale = 1;
        Debug.Log("hsuhfihf");
    }
    
}
