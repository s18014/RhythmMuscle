using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ButtleState : MonoBehaviour
{
    private static ButtleState instance;
    private static GameObject obj;
    public static ButtleState Instance
    {
        get
        {
            if (instance == null)
            {
                obj = new GameObject("ButtleState");
                instance = obj.AddComponent<ButtleState>();
                Debug.Log("created");
            }
            return instance;
        }
    }

    [SerializeField] float baseInterval = 1.5f;
    [SerializeField] float minInterval = 0.15f;
    [SerializeField] float decreaseRatio = 0.3f;
    [SerializeField] float baseRestTime = 3f;
    public float interval;
    public int turn = 0;
    public int combo = 0;
    public bool isPlayerTurn = false;
    public bool isPlayerTurnEnd = false;
    public bool isEnemyTurn = false;
    public bool isEnemyTurnEnd = false;
    public bool isStop = false;
    public bool isButtleStart = false;
    public bool isGameClear = false;
    public bool isGameOver = false;
    public bool isGameEnd = false;
    public bool isPlayerInit = false;
    public float time;
    public float restTime;
    public PlayerInput.DirectionType directionType;
 
    // Start is called before the first frame update

    private void Awake()
    {
        interval = baseInterval;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AddTurn()
    {
        turn++;
        // 状態を更新
        float ratio = (1 - turn * decreaseRatio);
        interval = ratio * baseInterval;
        if (interval < minInterval) interval = minInterval;
    }


    public void Delete()
    {
        Destroy(obj);
    }

    public void nextDirection()
    {
        int r = UnityEngine.Random.Range(0, 4);
        directionType = (PlayerInput.DirectionType)Enum.ToObject(typeof(PlayerInput.DirectionType), r);
    }
}
