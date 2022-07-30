
using System.Collections;
using UnityEngine;

public class Expire : MonoBehaviour
{

    [SerializeField] private float timeToLive;

    private void OnEnable()
    {
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(timeToLive);
        gameObject.SetActive(false);
    }

}
