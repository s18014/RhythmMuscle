using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] float baseInterval = 0.8f;
    public float interval;
    public int posingTimes = 5;
    public int turn = 0;
    public int combo = 0;
    public bool isPlayerTurn = false;
    public bool isEnemyTurn = true;
    public bool isStop = false;
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
        motionTypes = new List<string>();
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

    public void Delete()
    {
        Destroy(obj);
    }

}
