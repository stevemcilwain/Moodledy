
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{

    [SerializeField] private KeyCode startKey;

    private Image _panel;

    private bool _isPlaying;

    private void Awake()
    {
        _panel = GetComponentInChildren<Image>();
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            if (Input.GetKeyDown(startKey))
            {
                _isPlaying = true;
                _panel.gameObject.SetActive(false);
                Events.onGameStarted.Publish();
            }
        }
        else
        {
            if (Input.GetKeyDown(startKey))
            {
                _isPlaying = false;
                _panel.gameObject.SetActive(true);
                Events.onGameEnded.Publish();
            }
        }

    }

    private void OnRestart()
    {
        _panel.gameObject.SetActive(true);
    }


}
