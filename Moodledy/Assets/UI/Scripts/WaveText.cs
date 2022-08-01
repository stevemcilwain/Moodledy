

using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{

    [Header("Settings")]
    [Space(10)]

    [SerializeField] private float speed = 2f;
    [SerializeField] private float height = 0.01f;

    // Private Cache and State

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        _text.ForceMeshUpdate();

        var textInfo = _text.textInfo;

        for (int i = 0; i < textInfo.characterCount; i++)
        {
            var charInfo = textInfo.characterInfo[i];

            // skip spaces
            if (!charInfo.isVisible) continue;

            // get the vertices of the current character
            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            // move the verts for this character
            for (int j = 0; j < 4; j++)
            {
                var current = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = PositionVert(current);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            _text.UpdateGeometry(meshInfo.mesh, i);
        }

    }

    private Vector3 PositionVert(Vector3 current)
    {
        return current + new Vector3(0f, (Mathf.Sin(Time.time * speed + current.x) * height), 0f);
    }

}
