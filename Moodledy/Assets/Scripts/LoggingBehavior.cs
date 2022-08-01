
using UnityEngine;

public class LoggingBehavior : MonoBehaviour
{
    private const string FORMAT = "<color=#{0}><b>{1}</b>: {2}</color>";

    [Header("Settings")]
    [Space(10)]

    [Tooltip("Set the color for log messages")]
    [SerializeField] private Color logColor = Color.white;

    // Private State
    private string _htmlColor;

    // Unity Lifecycle

    private void Awake()
    {
        _htmlColor = ColorUtility.ToHtmlStringRGB(logColor);
    }

    // Public API

    public void LogInfo(string message)
    {
        Debug.LogFormat(gameObject, FORMAT, _htmlColor, gameObject.name, message);
    }

    public void LogWarning(string message)
    {
        Debug.LogWarningFormat(gameObject, FORMAT, _htmlColor, gameObject.name, message);
    }

    public void LogError(string message)
    {
        Debug.LogErrorFormat(gameObject, FORMAT, _htmlColor, gameObject.name, message);
    }

}
