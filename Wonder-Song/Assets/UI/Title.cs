using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Title : MonoBehaviour
{

    //adjust this to change speed
    public float speed = 0.5f;
    public float height = 1f;
    //adjust this to change how high it goes
    public float offset = 0.5f;

    private float _x;
    private float _y;

    private void Awake()
    {
        _x = transform.position.x;
        _y = transform.position.y;
    }

    private void Start()
    {

    }

    private void Update()
    {

        float y = (_y + (Mathf.Sin((Time.time + offset) * Mathf.PI * speed) * height));
        transform.position = new Vector2(_x, y);
    }


}
