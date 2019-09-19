using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] int MaxMP = 100;
    [SerializeField] Text testText;
    int posingCount;
    int MP;
    bool isStart = false;
    float time;
    AudioSource audio;

    private void Awake()
    {
        MP = MaxMP;
        audio = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ButtleState.Instance.isEnemyTurn)
        {
            // 初期化処理
            if (!isStart)
            {
                posingCount = 0;
                time = 0;
                isStart = true;
            }

            time += Time.deltaTime;
            float posingTime = (posingCount + 1) * ButtleState.Instance.interval;
            // ポージングの回数判定
            if (posingCount < ButtleState.Instance.posingTimes)
            {
                // 一定間隔でポージング
                if (posingTime < time)
                {
                    Debug.Log(time);
                    Debug.Log(ButtleState.Instance.notes[posingCount].posingType);

                    // TODO: ポージングのアニメーション
                    // TODO: 音
                    audio.Play();

                    posingCount++;
                }
            }

            // 終了判定 １サイクル分　余韻を作っている
            if ((ButtleState.Instance.posingTimes + 1) * ButtleState.Instance.interval <= time)
            {
                Debug.Log(time);
                ButtleState.Instance.isEnemyTurn = false;
                isStart = false;
                ButtleState.Instance.AddTurn();
            }


        }
    }
}
