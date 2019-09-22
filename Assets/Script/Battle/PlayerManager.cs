using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PosingController posingController;

    private void Awake()
    {
        posingController = GetComponent<PosingController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInput.swipeState != SwipeType.IDLE)
        {
            posingController.DoPosing(PlayerInput.swipeState);
        }
    }
}
