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

    [Space(10)]
    [SerializeField] private float danceY;
    [SerializeField] private float danceZ;

    // Public State

    public bool Ready => _ready;

    // Private State
    private LoggingBehavior _log;
    private bool _ready;

    private bool _danceShirtUp;
    private bool _danceHeadLeft;

    private void Awake()
    {
        _log = GetComponent<LoggingBehavior>();
        _danceShirtUp = (Random.value > 0.5f);
        _danceHeadLeft = (Random.value > 0.5f);
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
        SetPositionY(face, layout.FaceY);

        hair.GetComponent<SpriteHairChooser>().ChooseHairAndBangs();
        SetPositionY(hair, layout.HairY);
        SetPositionY(bangs, layout.BangsY);

        shirt.GetComponent<SpriteChooser>().Choose();
        SetPositionY(shirt, layout.ShirtY);

        SetPositionY(pants, layout.PantsY);

        _ready = true;

    }

    private void OnEnable()
    {
        GameEventManager.onMusicBeat.AddSubscriber(OnMusicBeat);
    }

    private void OnDisable()
    {
        GameEventManager.onMusicBeat.RemoveSubscriber(OnMusicBeat);
    }


    // Event Handlers

    private void OnMusicBeat()
    {
        if (_danceShirtUp)
        {
            _danceShirtUp = false;
            SetY(shirt, -danceY);
        }
        else
        {
            _danceShirtUp = true;
            SetY(shirt, danceY);
        }

        if (_danceHeadLeft)
        {
            _danceHeadLeft = false;
            RotateZ(face, -danceZ);
            RotateZ(hair, -danceZ);
            RotateZ(bangs, -danceZ);
        }
        else
        {
            _danceHeadLeft = true;
            RotateZ(face, danceZ);
            RotateZ(hair, danceZ);
            RotateZ(bangs, danceZ);
        }

    }


    // Private Methods

    private void SetPositionY(GameObject go, float y)
    {
        go.transform.localPosition = new Vector2(go.transform.localPosition.x, y);
    }

    private void SetY(GameObject go, float y)
    {
        go.transform.localPosition = new Vector2(go.transform.localPosition.x, go.transform.localPosition.y + y);
    }

    private void RotateZ(GameObject go, float z)
    {
        go.transform.Rotate(0f, 0f, z, Space.World);
    }

}
