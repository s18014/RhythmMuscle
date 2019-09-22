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
    float endTime = 1f;
    float currentTime;
    bool isPosing = false;

    // Start is called before the first frame update
    void Start()
    {
        allUnActive();
        Idle();
    }

    // Update is called once per frame
    void Update()
    {
        updateState();
        checkPosingState();
    }

    public void setEndTime(float endTime)
    {
        this.endTime = endTime;
    }

    void initPosingState()
    {
        isPosing = true;
        currentTime = 0f;
    }

    void updateState()
    {
        currentTime += Time.deltaTime;
    }

    void checkPosingState()
    {
        if (isPosing && currentTime < endTime)
        {
            return;
        }
        Idle();
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
        initPosingState();
    }

    public void Down()
    {
        allUnActive();
        down.gameObject.SetActive(true);
        initPosingState();
    }

    public void Right()
    {
        allUnActive();
        right.gameObject.SetActive(true);
        initPosingState();
    }

    public void Left()
    {
        allUnActive();
        left.gameObject.SetActive(true);
        initPosingState();
    }

    public void Idle()
    {
        allUnActive();
        idle.gameObject.SetActive(true);
    }
}
