using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatGenerator : MonoBehaviour
{

    public void Beat()
    {
        Events.onMusicBeat.Publish();
    }
}
