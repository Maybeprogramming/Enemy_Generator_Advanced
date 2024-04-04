using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnersFactory : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemiesTemplates;
    [SerializeField] private Transform[] _points;
    [SerializeField] private Target[] _targets;
    [SerializeField] private Spawner _spawnerTemplate;    
    [SerializeField] private Timer _timer;
    [SerializeField] private List<Spawner> _spawners;

    private System.Random _random = new System.Random();

    private void Awake()
    {
        FillSpawners();
    }

    private void OnEnable()
    {
        _timer.Triggered += OnSpawned;
    }

    private void OnDisable()
    {
        _timer.Triggered -= OnSpawned;
    }

    private void OnSpawned()
    {
        int spawnerIndex = _random.Next(0, _spawners.Count);
        Debug.Log(spawnerIndex);
        _spawners[spawnerIndex].OnSpawned();
    }

    private void FillSpawners()
    {
        for (int i = 0; i < _points.Length; i++)
        {
            var spawner = Instantiate(_spawnerTemplate, _points[i]);
            spawner.Init(_enemiesTemplates[i], _targets[i], _timer);
            _spawners.Add(spawner);
        }
    }
}
