using System;
using UnityEngine;

public static class GameEventManager
{

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("GameEventManager has loaded.");
    }

    #region ---------------------------------------- TEMPLATES

    // public static readonly GameEvent on = new();
    // public static readonly GameEvent<float> on = new();
    // public static readonly GameEvent<GameObject> on = new();

    #endregion

    public static readonly GameEvent onMusicBeat = new();

}
