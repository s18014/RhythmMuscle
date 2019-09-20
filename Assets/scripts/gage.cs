using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gage : MonoBehaviour
{
    Slider hpSlider;

    // Use this for initialization
    void Start()
    {

        hpSlider = GetComponent<Slider>();

        float maxHp = 200f;
        float nowHp = 200f;


        //スライダーの最大値の設定
        hpSlider.maxValue = maxHp;

        //スライダーの現在値の設定
        hpSlider.value = nowHp;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hpSlider.value -= 10;
        }
    }
    public void Methot()
    {
        Debug.Log("現在値" + hpSlider.value);

        if(hpSlider.value >= 50)
        {
            Debug.Log("50以上です。");
        }
    } 


}
