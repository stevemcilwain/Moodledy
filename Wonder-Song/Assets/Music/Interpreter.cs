using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpreter : MonoBehaviour
{

    private List<Notes> _notes;
    private bool _processing;

    private void OnEnable()
    {
        _notes = new List<Notes>();
        _processing = false;

        Events.onMusicNote.Add(OnMusicNote);
        Events.onGameStarted.Add(OnGameStarted);
        Events.onGameEnded.Add(OnGameEnded);
    }

    private void OnDisable()
    {
        StopAllCoroutines();

        Events.onMusicNote.Remove(OnMusicNote);
        Events.onGameStarted.Add(OnGameStarted);
        Events.onGameEnded.Add(OnGameEnded);
    }

    private void OnGameStarted()
    {
        _notes = new List<Notes>();
        _processing = false;
        StartCoroutine(ProcessNotes());
    }

    private void OnGameEnded()
    {
        StopAllCoroutines();
    }

    private void OnMusicNote(Notes note)
    {
        _notes.Add(note);
    }

    private IEnumerator ProcessNotes()
    {
        while (true)
        {
            yield return null;

            // dequeue 3
            if (_notes.Count >= 20)
            {
                if (!_processing)
                {
                    _processing = true;

                    yield return null;

                    var trend = GetTrend();

                    if (trend >= 3)
                    {
                        Events.onHappyNotes.Publish();
                        yield return null;

                    }
                    else if (trend <= -3)
                    {
                        Events.onSadNotes.Publish();
                        yield return null;
                    }
                    else
                    {
                        Events.onNeutralNotes.Publish();
                        yield return null;
                    }

                    //_notes.Clear();

                    _processing = false;
                }
            }

            yield return null;
        }
    }

    private int GetTrend()
    {
        int trend = 0;

        for (int i = 0; i < _notes.Count - 1; i++)
        {
            var next = (int)_notes[i + 1];
            var current = (int)_notes[i];

            var diff = next - current;

            if (diff > 0)
            {
                trend++;
            }
            else if (diff < 0)
            {
                trend--;
            }
        }




        return trend;

    }

}
