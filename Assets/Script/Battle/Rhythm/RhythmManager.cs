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

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            testNotes.Add(Instantiate(notePrefab));
            testNotes[i].GetComponent<Note>().judgeTime = (i + 1) * 1f;
            testNotes[i].transform.parent = canvas.transform;
            testNotes[i].GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        testNotes.ForEach(note =>
        {
            float judgePointX = judgePoint.GetComponent<RectTransform>().anchoredPosition.x;
            float length = 300f;
            float speed = 3f;
            float posX = judgePointX + (note.GetComponent<Note>().judgeTime - time) * length * speed;
            note.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0f);
        });
    }

    void Draw()
    {
    }
}
