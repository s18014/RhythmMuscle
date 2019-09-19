using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    static List<string> posingTypes = new List<string>()
    {
        "UP",
        "DOWN",
        "LEFT",
        "RIGHt"
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static List<PosingNote> Generate(int number, float interval)
    {
        List<PosingNote> notes = new List<PosingNote>();
        for (int i = 1; i <= number; i++)
        {
            PosingNote note = new PosingNote();
            note.judgeTime = i * interval;
            note.posingType = posingTypes[(int)Random.Range(0, 3)];
            notes.Add(note);
        }
        return notes;
    }
}
