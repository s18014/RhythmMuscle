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
    float posingTime = 0.7f;
    float currentTime = 0f;
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
        if (isPosing)
        {
            currentTime += Time.deltaTime;
            if (currentTime > posingTime)
            {
                Idle();
                isPosing = false;
            }
        }
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
        if (type != SwipeType.IDLE)
        {
            isPosing = true;
            currentTime = 0f;
        }
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
