using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Mouth : MonoBehaviour
{

    [Header("Mood Thresholds")]
    [Space(10)]

    [SerializeField] private int moodTop = 50;
    [SerializeField] private int moodBottom = -50;

    [Header("Smiles")]
    [Space(10)]
    [SerializeField] private int moodSmile1 = 15;
    [SerializeField] private int moodSmile2 = 30;

    [Header("Frowns")]
    [Space(10)]
    [SerializeField] private int moodFrown1 = -15;
    [SerializeField] private int moodFrown2 = -30;


    protected SpriteResolver _resolver;
    protected string _category = "Mouths";
    protected List<string> _labels;

    [Space(10)]
    public int _mood;

    private void Awake()
    {
        _resolver = GetComponentInChildren<SpriteResolver>();
        _labels = new List<string>();
        _labels.AddRange(_resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(_category));
    }


    private void OnEnable()
    {
        _mood = 0;
        _resolver.SetCategoryAndLabel(_category, _labels[0]);

        Events.onHappyNotes.Add(OnHappyNotes);
        Events.onSadNotes.Add(OnSadNotes);
        Events.onNeutralNotes.Add(OnNeutralNotes);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Events.onHappyNotes.Remove(OnHappyNotes);
        Events.onSadNotes.Remove(OnSadNotes);
        Events.onNeutralNotes.Remove(OnNeutralNotes);
    }


    private void Update()
    {

        string label = _labels[0];

        // Smile Conditions

        if (_mood >= moodSmile1 && _mood < moodSmile2)
        {
            label = _labels[1];
        }
        else if (_mood >= moodSmile2)
        {
            label = _labels[2];
        }

        // Frown Conditions

        if (_mood <= moodFrown1 && _mood > moodFrown2)
        {
            label = _labels[3];
        }
        else if (_mood <= moodFrown2)
        {
            label = _labels[4];
        }

        _resolver.SetCategoryAndLabel(_category, label);

    }

    private void OnHappyNotes()
    {
        if (_mood >= moodTop) return;
        _mood++;

    }

    private void OnSadNotes()
    {
        if (_mood <= moodBottom) return;
        _mood--;
    }

    private void OnNeutralNotes()
    {
        // return mood to neutral

        if (_mood == 0) return;

        if (_mood < 0) _mood++;

        if (_mood > 0) _mood--;
    }
}
