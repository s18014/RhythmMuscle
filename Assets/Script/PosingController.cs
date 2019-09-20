using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosingController : MonoBehaviour
{
    [SerializeField] GameObject up;
    [SerializeField] GameObject down;
    [SerializeField] GameObject right;
    [SerializeField] GameObject left;
    [SerializeField] GameObject idle;
    /*
    float endTime = 1f;
    float currentTime;
    bool isPosing = false;
    */

    // Start is called before the first frame update
    void Start()
    {
        allUnActive();
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (isPosing && currentTime < endTime)
        {
            currentTime += Time.deltaTime;
            return;
        }

        Idle();
        */
    }

    void allUnActive()
    {
        up.gameObject.SetActive(false);
        down.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        left.gameObject.SetActive(false);
        idle.gameObject.SetActive(false);
    }

    public void Up()
    {
        allUnActive();
        up.gameObject.SetActive(true);
    }

    public void Down()
    {
        allUnActive();
        down.gameObject.SetActive(true);
    }

    public void Right()
    {
        allUnActive();
        right.gameObject.SetActive(true);
    }

    public void Left()
    {
        allUnActive();
        left.gameObject.SetActive(true);
    }

    public void Idle()
    {
        allUnActive();
        idle.gameObject.SetActive(true);
    }
}
