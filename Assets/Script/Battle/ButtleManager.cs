using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtleManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Player player;
    [SerializeField] Text comboText;
    [SerializeField] Slider restTimeBar;
    [SerializeField] Text startText;
    SceneLoader sceneLoader;
    ButtleState buttleState;
    Score score;
    // Start is called before the first frame update

    private void Awake()
    {
        buttleState = ButtleState.Instance;
        sceneLoader = GetComponent<SceneLoader>();
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameState();
        TextUpdate();
        if (!buttleState.isButtleStart)
        {
            if (PlayerInput.touched)
            {
                startText.text = "";
                buttleState.isButtleStart = true;
                buttleState.nextDirection();
                buttleState.isEnemyTurn = true;
            }
        }

        if (buttleState.isGameClear)
        {
            // TODO: リザルト画面へ
        }

        if (buttleState.isGameOver)
        {
            // TODO: リザルト画面へ
        }

        if (!buttleState.isGameEnd)
        {
            PlayerAction();
            EnemyAction();
        }
        /*
        if (buttleState.isButtleStart && !buttleState.isGameEnd)
        {
            PlayerAction();
            EnemyAction();
            if (buttleState.isEnemyTurnEnd)
            {
                buttleState.isPlayerTurn = true;
                buttleState.isEnemyTurnEnd = false;
            }

            if (buttleState.isPlayerTurnEnd)
            {
                buttleState.isEnemyTurn = true;
                buttleState.isPlayerTurnEnd = false;
                buttleState.nextDirection();
            }

         }
         */
    }

    void CheckGameState()
    {
        if (player.getMP() <= 0)
        {
            buttleState.isGameOver = true;
            buttleState.isGameEnd = true;
        }
        if (enemy.getMP() <= 0)
        {
            buttleState.isGameClear = true;
            buttleState.isGameEnd = true;
        }
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
            if (!player.init)
            {
                buttleState.time = 0;
                player.init = true;
            }

            buttleState.time += Time.deltaTime;

            if (PlayerInput.direction != PlayerInput.DirectionType.IDLE)
            {
                if (PlayerInput.direction == buttleState.directionType)
                {
                    enemy.ApplyDamage(player.getAttack() * (1 + buttleState.combo * 0.05f));
                    buttleState.combo++;
                } else
                {
                    buttleState.combo = 0;
                    player.ApplyDamage();
                }
                buttleState.isPlayerTurn = false;
                buttleState.isEnemyTurn = true;
                buttleState.nextDirection();
                player.init = false;
            }

            if (buttleState.time > buttleState.interval)
            {
                buttleState.combo = 0;
                player.ApplyDamage();
                buttleState.isPlayerTurn= false;
                buttleState.isEnemyTurn = true;
                buttleState.nextDirection();
                player.init = false;
            }
        }
    }

    void EnemyAction()
    {
        if (buttleState.isEnemyTurn)
        {
            Debug.Log("HOGE");
            if (!enemy.init)
            {
                buttleState.enemyPosingTime = 0f;
                enemy.init = true;
                enemy.DoPosing(PlayerInput.DirectionType.IDLE);
            }

            buttleState.enemyPosingTime += Time.deltaTime;

            if (buttleState.enemyPosingTime > 0.3f)
            {
                enemy.DoPosing(buttleState.directionType);
                buttleState.isEnemyTurn = false;
                buttleState.isPlayerTurn = true;
                enemy.init = false;
            }
        }
    }
}
