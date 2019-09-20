using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MaxMP = 100f;
    [SerializeField] float recoveryPoint = 30f;
    [SerializeField] Slider MPBar;
    int posingCount;
    float MP;
    bool isStart = false;
    float time;
    public bool init = false;
    AudioSource audio;
    ButtleState buttleState;
    PosingController posingController;

    private void Awake()
    {
        MP = MaxMP;
        audio = GetComponent<AudioSource>();
        buttleState = ButtleState.Instance;
        posingController = GetComponent<PosingController>();
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MPBar.value = MP / MaxMP;
    }

    void Recover()
    {
        if (MP <= 0) return;
        MP += recoveryPoint * Time.deltaTime;
        if (MP >= MaxMP) MP = MaxMP;
    }

    public bool isDead()
    {
        return MP <= 0f;
    }
    /*
    void RhythmPatern()
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
    */

    public float getMP()
    {
        return MP;
    }

    public void ApplyDamage(float damage)
    {
        MP -= damage;
        if (MP < 0)
        {
            MP = 0;
            buttleState.isGameClear = true;
        }

        Debug.Log("敵がダメージ");
    }

    public void DoPosing(PlayerInput.DirectionType direction)
    {
        switch(direction)
        {
            case PlayerInput.DirectionType.UP:
                posingController.Up();
                break;
            case PlayerInput.DirectionType.DOWN:
                posingController.Down();
                break;
            case PlayerInput.DirectionType.RIGHT:
                posingController.Right();
                break;
            case PlayerInput.DirectionType.LEFT:
                posingController.Left();
                break;
            case PlayerInput.DirectionType.IDLE:
                posingController.Idle();
                break;
            default:
                break;
        }
    }
}
