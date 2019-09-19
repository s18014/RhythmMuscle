using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    [SerializeField] int MaxMP = 100;
    [SerializeField] Text testText;
    int posingTimes;
    int MP;

    private void Awake()
    {
        MP = MaxMP;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        while (!ButtleState.Instance.isPlayerTurn)
        {
            
        }
    }
}
