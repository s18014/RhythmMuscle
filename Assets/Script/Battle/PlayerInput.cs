using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public static SwipeType swipeState
    {
        get;
        private set;
    }

    Vector3 touchStartPos;
    Vector3 touchEndPos;

    public static bool touched
    {
        get;
        private set;
    }

    private void Awake()
    {
        swipeState = SwipeType.IDLE;
        touched = false;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Flick();
    }

    void Flick()
    {
        swipeState = SwipeType.IDLE;
        touched = false;
     	if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                touchStartPos = new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    Input.mousePosition.z);
            }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                touchEndPos = new Vector3(Input.mousePosition.x,
                    Input.mousePosition.y,
                    Input.mousePosition.z);

                GetswipeState();
            }
    }

    void GetswipeState ()
	{
        float distance = Vector3.Distance(touchStartPos, touchEndPos);
		float swipeStateX = touchEndPos.x - touchStartPos.x;
		float swipeStateY = touchEndPos.y - touchStartPos.y;
        // スワイプ距離が30f以下の場合はタップ判定
        if (distance <= 30f)
        {
            touched = true;
            return;
        }
		//xがｙより絶対値が大きい時。
		if (Mathf.Abs (swipeStateY) < Mathf.Abs (swipeStateX)) {
			if (30 < swipeStateX) {
				//右向きにフリック
				swipeState = SwipeType.RIGHT;

			} 
			if (-30 > swipeStateX) {
				//左向きにフリック
				swipeState = SwipeType.LEFT;
			}
			//yがxより絶対値が大きい時。
		} else if (Mathf.Abs (swipeStateX) < Mathf.Abs (swipeStateY)) {
			if (30 < swipeStateY) {
				//上向きにフリック
				swipeState = SwipeType.UP;
			}
			if (-30 > swipeStateY) {
				//下向きのフリック
				swipeState = SwipeType.DOWN;
			}
		} else {
            //タッチを検出
            touched = true;
		}
	}
}
