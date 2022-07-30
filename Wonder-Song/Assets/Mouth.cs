using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Mouth : MonoBehaviour
{

    [SerializeField] private float neutralizerInterval;

    protected SpriteResolver _resolver;
    protected string _category = "Mouths";
    protected List<string> _labels;

    private int _happyCount;
    private int _sadCount;

    private WaitForSeconds _interval;

    private void Awake()
    {

        _resolver = GetComponentInChildren<SpriteResolver>();
        _labels = new List<string>();
        _labels.AddRange(_resolver.spriteLibrary.spriteLibraryAsset.GetCategoryLabelNames(_category));
    }


    private void OnEnable()
    {
        neutralizerInterval = 0.5f;
        _interval = new WaitForSeconds(neutralizerInterval);
        _happyCount = 0;
        _sadCount = 0;
        _resolver.SetCategoryAndLabel(_category, _labels[0]);
        StartCoroutine(Neutralizer());
        Events.onHappyNotes.Add(OnHappyNotes);
        Events.onSadNotes.Add(OnSadNotes);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
        Events.onHappyNotes.Remove(OnHappyNotes);
        Events.onSadNotes.Remove(OnSadNotes);
    }


    private void Update()
    {

        string label = _labels[0];

        if (_happyCount > 5 && _happyCount < 20)
        {
            label = _labels[1];
        }
        else if (_happyCount >= 20)
        {
            label = _labels[2];
        }

        _resolver.SetCategoryAndLabel(_category, label);

    }

    private void OnHappyNotes()
    {
        _happyCount++;
    }

    private void OnSadNotes()
    {
        string label = _labels[3];
        _resolver.SetCategoryAndLabel(_category, label);
    }

    private IEnumerator Neutralizer()
    {
        while (true)
        {
            yield return _interval;

            if (_happyCount > 0) _happyCount--;
            if (_sadCount > 0) _sadCount--;
        }


    }

}
