using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleState : MonoBehaviour
{
    private static ButtleState instance;
    public static ButtleState Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("ButtleState");
                instance = obj.AddComponent<ButtleState>();
            }
            return instance;
        }
    }

    [SerializeField] float baseInterval = 0.5f;
    public int posingTimes = 5;
    public float interval;
    public int turn = 0;
    public int combo = 0;
    public bool isPlayerTurn = false;
    List<string> motionType = new List<string>()
    {
        "UP",
        "DOWN",
        "RIGHT",
        "LEFT"
    };
    public List<string> motionTypes
    {
        get;
        private set;
    }
 
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

    public void Initialize()
    {
        turn = 0;
        combo = 0;
    }

    public void StateUpdate()
    {
        // 状態を更新
        float decreaseRatio = (1 - turn * 0.02f);
        if (decreaseRatio < 0.3f) decreaseRatio = 0.3f;
        interval = decreaseRatio * baseInterval;
        Debug.Log(interval);
    }

    public void GenerateMotion()
    {
        // posingTimes分ポーズの作成
        motionTypes.Clear();
        for (int i = 0; i < posingTimes; i++)
        {
            motionTypes.Add(motionType[(int)Random.Range(0, motionType.Count-1)]);
        }

    }

}
