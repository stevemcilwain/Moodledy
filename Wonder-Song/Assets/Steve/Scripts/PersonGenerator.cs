using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGenerator : MonoBehaviour
{

    [Space(10)]
    [Header("References")]
    [Space(10)]

    [SerializeField] private PersonLayoutAsset layout;
    [SerializeField] private GameObject prefab;

    [Space(10)]
    [Header("Settings")]
    [Space(10)]

    [SerializeField] private Vector2 offscreen;

    public void Generate(Vector2 position, Transform parent)
    {

        GameObject go = Instantiate(prefab, offscreen, Quaternion.identity, parent);

        // choose random sprites

        // set the position to make it "live"

    }
}
