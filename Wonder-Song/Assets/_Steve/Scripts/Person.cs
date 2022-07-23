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

    [Space(10)]
    [Header("Events")]
    [Space(10)]

    // TODO: define what a Mood is
    public UnityEvent<GameObject> OnPersonMoodChanged;

    private void Awake()
    {
        ChooseHair();
        ChooseShirt();
        ChooseFace();
    }


    // Private Methods


    private void ChooseHair()
    {

    }

    private void ChooseShirt()
    {

    }

    private void ChooseFace()
    {

    }

}
