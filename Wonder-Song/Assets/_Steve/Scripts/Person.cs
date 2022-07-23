using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LoggingBehavior))]
public class Person : MonoBehaviour
{
    [Space(10)]
    [Header("References")]
    [Space(10)]

    [Tooltip("Assign a layout for this person's sprites")]
    [SerializeField] private PersonLayoutAsset layout;

    [Space(10)]

    [SerializeField] private GameObject hair;
    [SerializeField] private GameObject bangs;
    [SerializeField] private GameObject face;
    [SerializeField] private GameObject shirt;
    [SerializeField] private GameObject pants;

    // Public State

    public bool Ready => _ready;

    // Private State
    private LoggingBehavior _log;
    private bool _ready;

    private void Awake()
    {
        _log = GetComponent<LoggingBehavior>();
    }

    private void Start()
    {
        if (layout == null)
        {
            _log.LogError("PersonLayoutAsset is NOT ASSIGNED in the inspector!!!");
            return;
        }

        _log.LogInfo("Generating a new person...");

        face.GetComponent<SpriteChooser>().Choose();
        SetPosition(face, layout.FaceY);

        hair.GetComponent<SpriteHairChooser>().ChooseHairAndBangs();
        SetPosition(hair, layout.HairY);
        SetPosition(bangs, layout.BangsY);

        shirt.GetComponent<SpriteChooser>().Choose();
        SetPosition(shirt, layout.ShirtY);

        SetPosition(pants, layout.PantsY);

        _ready = true;

    }


    // Private Methods

    private void SetPosition(GameObject go, float y)
    {
        go.transform.localPosition = new Vector2(0f, y);
    }

}
