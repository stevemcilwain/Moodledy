using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Note : MonoBehaviour
{

    [SerializeField] private KeyCode keyMap;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashSeconds;
    [SerializeField] private Notes note;

    // Private State and Cache

    private AudioSource _source;
    private SpriteRenderer _renderer;
    private ParticlePool _pool;

    private void Awake()
    {
        _pool = GetComponent<ParticlePool>();
        _renderer = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyMap))
        {
            StartCoroutine(Play());
        }
    }
    private IEnumerator Play()
    {
        Events.onMusicNote.Publish(note);

        _source.PlayOneShot(_source.clip);

        _pool.Get().Play();

        _renderer.color = flashColor;
        yield return new WaitForSeconds(flashSeconds);
        _renderer.color = Color.white;
    }

}
