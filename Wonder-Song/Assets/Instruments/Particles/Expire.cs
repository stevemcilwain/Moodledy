using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{

    [SerializeField] private float timeToLive;

    private void Start()
    {
        Destroy(gameObject, timeToLive);
    }

}
