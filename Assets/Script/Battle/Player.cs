using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] int MaxMp = 200;
    [SerializeField] Text posingText;
    [SerializeField] Text inputText;
    AudioSource audio;

    int noteCount;
    bool isStart = false;
    float time;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        inputText.text = PlayerInput.direction;
        if (ButtleState.Instance.isPlayerTurn)
        {
            // 初期化処理
            if (!isStart)
            {
                time = 0;
                isStart = true;
            }

            time += Time.deltaTime;
            // あたり判定

            if (ButtleState.Instance.notes.Count > noteCount && ButtleState.Instance.notes[noteCount].judgeTime < time)
            {
                Debug.Log(ButtleState.Instance.notes[noteCount].judgeTime);
                noteCount++;
            }

            // 終了判定 
            if ((ButtleState.Instance.notes.Count+1) * ButtleState.Instance.interval <= time)
            {
                ButtleState.Instance.isPlayerTurn = false;
                isStart = false;
            }
        }
    }

    void applyDamage()
    {

    }
}
