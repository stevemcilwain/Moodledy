using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonGenerator : MonoBehaviour
{

    [Space(10)]
    [Header("References")]
    [Space(10)]

    [Tooltip("Assign one or more person prefabs to use for generation")]
    [SerializeField] private List<GameObject> prefabs;

    [Space(10)]
    [Header("Settings")]
    [Space(10)]

    [SerializeField] private Vector2 offscreen;

    // Private State
    private LoggingBehavior _log;

    // Unity Lifecycle

    private void Awake()
    {
        _log = GetComponent<LoggingBehavior>();
    }

    private void Start()
    {

        if (prefabs == null)
        {
            _log.LogWarning("No prefabs assigned to generate!");
            return;
        }

        StartCoroutine(GeneratePeople());

    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // kick off loading then
    }


    // Private Methods

    private IEnumerator GeneratePeople()
    {
        _log.LogInfo($"Gonna be mekkin' peeple...");

        foreach (GameObject prefab in prefabs)
        {
            GameObject go = Instantiate(prefab, offscreen, Quaternion.identity, transform);
            Person person = go.GetComponent<Person>();

            while (!person.Ready)
            {
                yield return null;
            }

            // TODO: place in the scene somewhere or raise an event
            person.transform.position = Vector3.zero;

            _log.LogInfo($"Made {person.name}");
        }
    }

}
