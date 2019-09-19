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
    [SerializeField] float minInterval = 0.15f;
    [SerializeField] float decreaseRatio = 0.3f;
    public float interval;
    public int posingTimes = 5;
    public int turn = 0;
    public int combo = 0;
    public bool isPlayerTurn = false;
    public bool isEnemyTurn = false;
    public bool isStop = false;
    List<string> motionType = new List<string>()
    {
        "up",
        "down",
        "right",
        "left"
    };
    public List<string> motionTypes
    {
        get;
        private set;
    }
    public List<PosingNote> notes = new List<PosingNote>();
 
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

    public void AddTurn()
    {
        turn++;
        // 状態を更新
        float ratio = (1 - turn * decreaseRatio);
        interval = ratio * baseInterval;
        if (interval < minInterval) interval = minInterval;
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

    public void GenerateNotes()
    {
        // posingTimes分Noteの作成
        notes = NoteGenerator.Generate(posingTimes, interval);
    }
}
