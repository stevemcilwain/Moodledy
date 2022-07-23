using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CountDownBehavior : MonoBehaviour
{
    [Header("Settings")]
    [Space(10)]

    [Tooltip("Set the countdown time start in seconds")]
    [SerializeField] private float time;

    [Tooltip("Set the countdown time tick in seconds")]
    [SerializeField] private float tick;

    [Tooltip("Enable to start counting when the game object is first enabled")]
    [SerializeField] private bool countOnStart;

    [Space(10)]
    [Header("Events")]
    [Space(10)]

    [Tooltip("Returns time elapsed and time remaining every tick")]
    [SerializeField] public UnityEvent<float, float> OnTick;

    [Tooltip("Returns the total time elapssed when completed")]
    [SerializeField] public UnityEvent<float> OnCompleted;

    // Private State

    private bool _started;
    private float _timeRemaining;
    private float _timeElapsed;
    private WaitForSeconds _wait;

    // Unity Lifecycle

    private void OnEnable()
    {
        if (countOnStart) StartCountDown();
    }

    // Public API

    public void StartCountDown()
    {
        StopAllCoroutines();
        _timeElapsed = 0f;
        _timeRemaining = time;
        _wait = new WaitForSeconds(tick);
        StartCoroutine(CountDown());
    }

    // Private Methods

    private IEnumerator CountDown()
    {
        while (_timeRemaining > 0f)
        {
            yield return _wait;
            _timeElapsed += tick;
            _timeRemaining -= tick;
            OnTick.Invoke(_timeElapsed, _timeRemaining);
        }

        OnCompleted.Invoke(_timeElapsed);

    }
}
