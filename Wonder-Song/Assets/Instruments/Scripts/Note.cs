using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Note : MonoBehaviour
{

    [SerializeField] private KeyCode keyMap;
    [SerializeField] private Material particleMaterial;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashSeconds;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private Notes note;

    // Private State and Cache

    private AudioSource _source;
    private SpriteRenderer _renderer;

    private void Awake()
    {
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

        Emit();

        _renderer.color = flashColor;
        yield return new WaitForSeconds(flashSeconds);
        _renderer.color = Color.white;
    }

    private void Emit()
    {
        var p = Instantiate<ParticleSystem>(particles, transform.position, Quaternion.identity);
        p.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        p.Play();
    }

}
