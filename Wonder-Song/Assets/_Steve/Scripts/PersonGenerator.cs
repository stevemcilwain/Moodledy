using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Public API

    public void Generate(Vector2 position, Transform parent)
    {
        // TODO: choose random prefab

        GameObject go = Instantiate(prefabs[0], offscreen, Quaternion.identity, parent);

        // choose random sprites

        // set the position to make it "live"

    }
}
