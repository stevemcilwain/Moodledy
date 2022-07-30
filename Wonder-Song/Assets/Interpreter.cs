using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour
{

    private Stack<Notes> _played;


    private void OnEnable()
    {
        _played = new Stack<Notes>();
        Events.onMusicNote.Add(OnMusicNote);
    }

    private void OnDisable()
    {
        Events.onMusicNote.Remove(OnMusicNote);
    }

    private void OnMusicNote(Notes note)
    {
        // Notes previous;

        // var result = _played.TryPop(out previous);

        _played.Push(note);

        Events.onHappyNotes.Publish();

        // var value = (int)note;


    }

}
