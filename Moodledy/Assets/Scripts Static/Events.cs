using UnityEngine;

public static class Events
{

    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        Debug.Log("Events static class has loaded.");
    }

    #region ---------------------------------------- TEMPLATES

    // public static readonly GameEvent on = new();
    // public static readonly GameEvent<float> on = new();
    // public static readonly GameEvent<GameObject> on = new();

    #endregion

    public static readonly GameEvent onGameStarted = new();
    public static readonly GameEvent onGameEnded = new();

    public static readonly GameEvent onMusicBeat = new();

    public static readonly GameEvent<Notes> onMusicNote = new();

    // Notes
    public static readonly GameEvent onNeutralNotes = new();
    public static readonly GameEvent onHappyNotes = new();
    public static readonly GameEvent onSadNotes = new();

}
