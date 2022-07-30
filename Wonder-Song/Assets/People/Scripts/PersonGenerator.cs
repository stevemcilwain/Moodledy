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

    [Tooltip("The number of people to generate per prefab")]
    [Range(1, 20)]
    [SerializeField] private int countPerPrefab;
    [SerializeField] private Vector2 offscreen;

    [Space(10)]

    [SerializeField] private Vector2[] spawnPoints;

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
        StartCoroutine(GeneratePeople());
    }


    // Private Methods

    private IEnumerator GeneratePeople()
    {
        _log.LogInfo($"Gonna be mekkin' peeple...");

        foreach (GameObject prefab in prefabs)
        {
            for (int i = 0; i < countPerPrefab; i++)
            {
                GameObject go = Instantiate(prefab, offscreen, Quaternion.identity, transform);
                Person person = go.GetComponent<Person>();

                while (!person.Ready)
                {
                    yield return null;
                }

                //Vector2 randomPosition = RandomVectorWithinBounds();
                person.transform.localPosition = spawnPoints[i];

                _log.LogInfo($"Made {person.name}");
            }


        }
    }

    private Vector2 RandomVectorWithinBounds()
    {
        // Assumes 720P at 100 Pixels per Unit

        float buffer = 0.5f;

        float randomX = Random.Range(-6.1f + buffer, 6.1f - buffer); // at 720P 100 PPU, width is 12.8 units
        float randomY = Random.Range(-3.6f + buffer, 0f); // at 720P 100 PPU, width is 7.2 units

        Vector2 rV = new(randomX, randomY);

        return rV;

    }

}
