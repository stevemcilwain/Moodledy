using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Person : MonoBehaviour
{

    [Space(10)]
    [Header("References")]
    [Space(10)]

    [Tooltip("Assign a layout for this person's sprites")]
    [SerializeField] private PersonLayoutAsset layout;

    // Public State

    public bool Ready => _ready;

    // Private State
    private LoggingBehavior _log;
    private bool _ready;

    private void Awake()
    {
        _log = GetComponent<LoggingBehavior>();
    }

    private IEnumerator Start()
    {

        yield return null;

        _log.LogInfo("Generating a new person...");

        ChooseHair();
        yield return null;

        ChooseShirt();
        yield return null;

        ChooseFace();
        yield return null;

        ChooseBangs();
        yield return null;

        _ready = true;

    }


    // Private Methods

    private void ChooseHair()
    {
        _log.LogInfo("Choosing hair...");

        // short or long hair?
    }

    private void ChooseShirt()
    {
        _log.LogInfo("Choosing shirt...");
    }

    private void ChooseFace()
    {
        _log.LogInfo("Choosing face...");
    }

    private void ChooseBangs()
    {
        _log.LogInfo("Choosing bangs...");
    }

}
