using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float MaxMP = 100f;
    [SerializeField] Slider MPBar;
    [SerializeField] float attack = 5f;
    AudioSource audio;

    float MP;
    int noteCount;
    bool isStart = false;
    float time;
    ButtleState buttleState;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        buttleState = ButtleState.Instance;
        MP = MaxMP;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MPBar.value = MP / MaxMP;
        DoPosing(PlayerInput.direction);
    }

    public float getMP()
    {
        return MP;
    }

    public float getAttack()
    {
        return attack;
    }

    public void ApplyDamage()
    {
        MP -= 10f;
        if (MP < 0f) MP = 0f;
    }

    public void DoPosing(PlayerInput.DirectionType direction)
    {
        switch(direction)
        {
            case PlayerInput.DirectionType.UP:
                break;
            case PlayerInput.DirectionType.DOWN:
                break;
            case PlayerInput.DirectionType.RIGHT:
                break;
            case PlayerInput.DirectionType.LEFT:
                break;
            default:
                break;
        }
    }


    /*
    void RhythmPatern()
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

            // 終了判定 
            if ((buttleState.notes.Count + 1) * buttleState.interval <= time)
            {
                buttleState.isPlayerTurn = false;
                isStart = false;
            }
        }
    }
    */
}
