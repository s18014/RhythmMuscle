using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    Vector3 touchStartPos;
    Vector3 touchEndPos;
    public static string direction
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
        direction = "idle";
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
        direction = "idle";
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
		float directionX = touchEndPos.x - touchStartPos.x;
		float directionY = touchEndPos.y - touchStartPos.y;
		//xがｙより絶対値が大きい時。
		if (Mathf.Abs (directionY) < Mathf.Abs (directionX)) {
			if (30 < directionX) {
				//右向きにフリック
				direction = "right";

			} 
			if (-30 > directionX) {
				//左向きにフリック
				direction = "left";
			}
			//yがxより絶対値が大きい時。
		} else if (Mathf.Abs (directionX) < Mathf.Abs (directionY)) {
			if (30 < directionY) {
				//上向きにフリック
				direction = "up";
			}
			if (-30 > directionY) {
				//下向きのフリック
				direction = "down";
			}
		} else {
            //タッチを検出
            touched = true;
		}
		switch (direction) {
		case "up":
			//上フリックされた時の処理
			break;

		case "down":
			//下フリックされた時の処理
			break;

		case "right":
			//右フリックされた時の処理
			break;

		case "left":
			//左フリックされた時の処理
			break;

		case "touch":
			//タッチされた時の処理
			break;
		}

	}
}
