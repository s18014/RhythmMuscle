using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Player player;
    [SerializeField] Text comboText;
    [SerializeField] Text enemyStateText;
    [SerializeField] Slider restTimeBar;
    ButtleState buttleState;
    Score score;
    // Start is called before the first frame update

    private void Awake()
    {
        buttleState = ButtleState.Instance;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();
        TextUpdate();
        if (PlayerInput.touched)
        {
            if (!buttleState.isButtleStart)
            {
                buttleState.isButtleStart = true;
                buttleState.nextDirection();
                buttleState.isEnemyTurn = true;
            }
        }

        if (buttleState.isEnemyTurnEnd)
        {
            enemy.DoPosing(PlayerInput.DirectionType.IDLE);
            buttleState.isPlayerTurn = true;
            buttleState.isEnemyTurnEnd = false;
        }

        if (buttleState.isPlayerTurnEnd)
        {
            buttleState.isEnemyTurn = true;
            buttleState.isPlayerTurnEnd = false;
            buttleState.nextDirection();
        }

        if (buttleState.isButtleStart)
        {
            PlayerAction();
            EnemyAction();
            if (buttleState.isGameClear)
            {
                // TODO: リザルト画面へ
            }

            if (buttleState.isGameOver)
            {
                // TODO: リザルト画面へ
            }
        }
    }

    void CheckGameState()
    {
        if (player.getMP() <= 0) buttleState.isGameOver = true;
        if (enemy.getMP() <= 0) buttleState.isGameOver = true;
    }

    void TextUpdate()
    {
        if (buttleState.combo > 0)
        {
            comboText.text = buttleState.combo.ToString() + " COMBO!!!";
        } else
        {
            comboText.text = "";
        }
    }

    void PlayerAction()
    {
        if (buttleState.isPlayerTurn)
        {
            restTimeBar.value = 1 - (buttleState.time / buttleState.interval);
            Debug.Log(buttleState.directionType);
            // 初期化処理
            if (!buttleState.isPlayerInit)
            {
                buttleState.time = 0;
                buttleState.isPlayerInit = true;
            }

            buttleState.time += Time.deltaTime;

            if (PlayerInput.direction != PlayerInput.DirectionType.IDLE)
            {
                if (PlayerInput.direction == buttleState.directionType)
                {
                    enemy.ApplyDamage(player.getAttack() * (1 + buttleState.combo * 0.1f));
                    buttleState.combo++;
                } else
                {
                    buttleState.combo = 0;
                    player.ApplyDamage();
                }
                buttleState.isPlayerTurnEnd = true;
                buttleState.isPlayerInit = false;
            }

            if (buttleState.time > buttleState.interval)
            {
                buttleState.combo = 0;
                player.ApplyDamage();
                buttleState.isPlayerTurnEnd = true;
                buttleState.isPlayerInit = false;
            }
        }
    }

    void EnemyAction()
    {
        if (buttleState.isEnemyTurn)
        {
            enemy.DoPosing(buttleState.directionType);
            enemyStateText.text = buttleState.directionType.ToString();
            // TODO; 敵のアニメーション
            // TODO; 敵の音再生
            buttleState.isEnemyTurnEnd = true;
        }
    }
}
