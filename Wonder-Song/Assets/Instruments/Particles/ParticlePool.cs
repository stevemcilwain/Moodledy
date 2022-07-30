using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{

    [SerializeField] private ParticleSystem prefab;
    [SerializeField] private Material particleMaterial;
    [SerializeField] private int count;

    private List<ParticleSystem> _pool;

    private void Start()
    {
        _pool = new List<ParticleSystem>();

        for (int i = 0; i < count; i++)
        {
            _pool.Add(Create());
        }
    }

    public ParticleSystem Get()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeInHierarchy)
            {
                _pool[i].gameObject.SetActive(true);
                return _pool[i];
            }
        }

        // Exhausted the pool, so just instantiate one and add it
        Debug.LogWarning($"{name}: increasing the pool to {_pool.Count + 1}");
        var ps = Create();
        _pool.Add(ps);
        return ps;
    }

    private ParticleSystem Create()
    {
        var ps = Instantiate<ParticleSystem>(prefab, transform.position, Quaternion.identity, transform);
        ps.GetComponent<ParticleSystemRenderer>().material = particleMaterial;
        ps.gameObject.SetActive(false);
        return ps;
    }

}
