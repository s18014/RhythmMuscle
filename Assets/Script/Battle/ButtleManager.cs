using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtleManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    Player player;
    Score score;
    // Start is called before the first frame update

    private void Awake()
    {
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.direction != "idle")
        {
            ButtleState.Instance.Delete();
        }
    }
}
