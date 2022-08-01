// Adapted from: 
// https://github.com/Madalaski/TextTutorial/blob/master/Assets/WordWobble.cs

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GradientText : MonoBehaviour
{
    [Header("Settings")]
    [Space(10)]

    [SerializeField] private Gradient gradient;

    [SerializeField] private float interval = 0.1f;
    [SerializeField] private float shift = 1f;
    [SerializeField] private float pattern = 0.001f;
    [SerializeField] private float wobbleX = 3.3f;
    [SerializeField] private float wobbleY = 2.5f;

    // Private Cache and State

    private TMP_Text _text;
    private Mesh _mesh;
    private Vector3[] _verts;

    List<int> _indexes;
    List<int> _lengths;

    private WaitForSeconds _wait;

    // Unity Lifecycle

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _indexes = new List<int> { 0 };
        _lengths = new List<int>();
    }

    private void Start()
    {
        string s = _text.text;

        for (int index = s.IndexOf(' '); index > -1; index = s.IndexOf(' ', index + 1))
        {
            _lengths.Add(index - _indexes[_indexes.Count - 1]);
            _indexes.Add(index + 1);
        }

        _lengths.Add(s.Length - _indexes[_indexes.Count - 1]);

        StartCoroutine(ChangeAsync());
    }

    private void Update()
    {
        //Change();
    }

    private void Change()
    {
        _text.ForceMeshUpdate();
        _mesh = _text.mesh;
        _verts = _mesh.vertices;

        Color[] colors = _mesh.colors;

        for (int w = 0; w < _indexes.Count; w++)
        {
            int wordIndex = _indexes[w];
            //Vector3 offset = Wobble(Time.time + w);

            for (int i = 0; i < _lengths[w]; i++)
            {
                TMP_CharacterInfo c = _text.textInfo.characterInfo[wordIndex + i];

                int index = c.vertexIndex;

                Vector3 offset = Wobble(Time.time + i);

                colors[index] = gradient.Evaluate(Mathf.Repeat(Time.time + _verts[index].x * pattern, shift));
                colors[index + 1] = gradient.Evaluate(Mathf.Repeat(Time.time + _verts[index + 1].x * pattern, shift));
                colors[index + 2] = gradient.Evaluate(Mathf.Repeat(Time.time + _verts[index + 2].x * pattern, shift));
                colors[index + 3] = gradient.Evaluate(Mathf.Repeat(Time.time + _verts[index + 3].x * pattern, shift));

                _verts[index] += offset;
                _verts[index + 1] += offset;
                _verts[index + 2] += offset;
                _verts[index + 3] += offset;


            }
        }

        _mesh.vertices = _verts;
        _mesh.colors = colors;
        _text.canvasRenderer.SetMesh(_mesh);
    }


    private Vector2 Wobble(float time)
    {
        return new Vector2(Mathf.Sin(time * wobbleX), Mathf.Cos(time * wobbleY));
    }

    private IEnumerator ChangeAsync()
    {
        while (true)
        {
            yield return new WaitForSeconds(interval);
            Change();

        }



    }


}
