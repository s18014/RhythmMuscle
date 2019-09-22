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
    float idleTime = 0.1f;
    float endTime = 0.1f;
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
        // updateState();
        // checkPosingState();
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

    public void DoPosing(SwipeType type)
    {
        StartCoroutine("Posing", type);
    }

    public void Idle()
    {
        allUnActive();
        idle.gameObject.SetActive(true);
    }

    IEnumerator Posing(SwipeType type)
    {
        Idle();
        yield return new WaitForSeconds(0.05f);
        allUnActive();
        switch(type)
        {
            case SwipeType.UP:
                up.gameObject.SetActive(true);
                break;
            case SwipeType.DOWN:
                down.gameObject.SetActive(true);
                break;
            case SwipeType.RIGHT:
                right.gameObject.SetActive(true);
                break;
            case SwipeType.LEFT:
                left.gameObject.SetActive(true);
                break;
            default:
                idle.gameObject.SetActive(true);
                break;
        }
    }
}
