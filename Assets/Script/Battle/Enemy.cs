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
        if (ButtleState.Instance.isEnemyTurn)
        {
            // 初期化処理
            if (!isStart)
            {
                posingCount = 0;
                time = 0;
                ButtleState.Instance.GenerateMotion();
                isStart = true;
            }

            time += Time.deltaTime;
            // 一定間隔でポージング
            if (posingCount * ButtleState.Instance.interval < time)
            {
                testText.text = ButtleState.Instance.motionTypes[posingCount];

                // TODO: ポージングのアニメーション
                // TODO: 音

                posingCount++;
            }

            // 終了判定
            if (posingCount >= ButtleState.Instance.posingTimes)
            {
                ButtleState.Instance.isEnemyTurn = false;
                isStart = false;
            }


        }
    }
}
