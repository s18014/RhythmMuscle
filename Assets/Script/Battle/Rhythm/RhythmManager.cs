using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RhythmManager : MonoBehaviour
{
    List<GameObject> testNotes = new List<GameObject>();
    [SerializeField] GameObject notePrefab;
    [SerializeField] Image judgePoint;
    [SerializeField] Canvas canvas;
    float time = 0f;
    float badTimeRange = 0.1f;
    float judgeTimeRange = 0.1f;
    int targetIndex = 0;

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            testNotes.Add(Instantiate(notePrefab));
            testNotes[i].GetComponent<Note>().judgeTime = (i + 1) * 1f;
            testNotes[i].transform.parent = canvas.transform;
            testNotes[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
        testNotes[0].GetComponent<Note>().isTarget = true;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        CheckTarget();
        NoteUpdate();
   }

    void NoteUpdate()
    {
        testNotes.ForEach(note =>
        {
            float judgePointX = judgePoint.GetComponent<RectTransform>().anchoredPosition.x;
            float length = 300f;
            float speed = 3f;
            float posX = judgePointX + (note.GetComponent<Note>().judgeTime - time) * length * speed;
            note.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0f);
            if (note.GetComponent<Note>().isTarget)
            {
                note.GetComponent<Image>().color = Color.red;
            }
            else
            {
                note.GetComponent<Image>().color = Color.green;
            }
        });
    }

    void judgeNote(Note note)
    {

    }

    void CheckTarget()
    {
        Note note = testNotes[targetIndex].GetComponent<Note>();
        if (note.isTarget)
        {
            // タッチの判定内に来たかどうか
            if (note.judgeTime + judgeTimeRange + badTimeRange >= time && note.judgeTime - judgeTimeRange - badTimeRange <= time)
            {
                // GOODの範囲かどうか
                if (note.judgeTime + judgeTimeRange >= time && note.judgeTime - judgeTimeRange <= time)
                {
                    if (PlayerInput.touched)
                    {
                        Debug.Log("GOOD");
                        ChangeNextTarget();
                    }
                }
                else
                {
                    if (PlayerInput.touched)
                {
                        Debug.Log("Bad: Touch Out Of Range");
                        ChangeNextTarget();
                    }
                }
            }
            // 判定時間 + 猶予時間が現在の時間を超えたら次のターゲットへ
            if (note.judgeTime + judgeTimeRange < time)
            {
                Debug.Log("Bad: Time Over");
                ChangeNextTarget();
            }
        }
    }

    void ChangeNextTarget()
    {
        testNotes[targetIndex].GetComponent<Note>().isTarget = false;
        if (targetIndex+1 < testNotes.Count)
        {
            targetIndex++;
            testNotes[targetIndex].GetComponent<Note>().isTarget = true;
        }
    }
}
