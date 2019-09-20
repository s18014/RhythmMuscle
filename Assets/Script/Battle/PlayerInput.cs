using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{

    public enum DirectionType
    {
        UP,
        DOWN,
        RIGHT,
        LEFT,
        IDLE
    }
    Vector3 touchStartPos;
    Vector3 touchEndPos;
    public static DirectionType direction
    {
        get;
        private set;
    }

    public static bool touched
    {
        get;
        private set;
    }

    private void Awake()
    {
        direction = DirectionType.IDLE;
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
        direction = DirectionType.IDLE;
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

                GetDirection();
            }
    }

    void GetDirection ()
	{
        float distance = Vector3.Distance(touchStartPos, touchEndPos);
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;
		//xがｙより絶対値が大きい時。
        if (distance <= 30f)
        {
            touched = true;
            return;
        }
		if (Mathf.Abs (directionY) < Mathf.Abs (directionX)) {
			if (30 < directionX) {
				//右向きにフリック
				direction = DirectionType.RIGHT;

			} 
			if (-30 > directionX) {
				//左向きにフリック
				direction = DirectionType.LEFT;
			}
			//yがxより絶対値が大きい時。
		} else if (Mathf.Abs (directionX) < Mathf.Abs (directionY)) {
			if (30 < directionY) {
				//上向きにフリック
				direction = DirectionType.UP;
			}
			if (-30 > directionY) {
				//下向きのフリック
				direction = DirectionType.DOWN;
			}
		} else {
            //タッチを検出
            touched = true;
		}
	}
}
