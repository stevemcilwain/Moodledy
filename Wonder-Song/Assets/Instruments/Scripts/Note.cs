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
    private bool _isPlaying;

    private void Awake()
    {
        _pool = GetComponent<ParticlePool>();
        _renderer = GetComponent<SpriteRenderer>();
        _source = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Events.onGameStarted.Add(OnGameStarted);
        Events.onGameEnded.Add(OnGameEnded);
    }

    private void OnDisbale()
    {
        Events.onGameStarted.Remove(OnGameStarted);
        Events.onGameEnded.Remove(OnGameEnded);
    }

    private void Update()
    {
        if (_isPlaying)
        {
            if (Input.GetKeyDown(keyMap))
            {
                StartCoroutine(Play());
            }
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

    private void OnGameStarted()
    {
        _isPlaying = true;
    }
    private void OnGameEnded()
    {
        _isPlaying = false;
    }


}
