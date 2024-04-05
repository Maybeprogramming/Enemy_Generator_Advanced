using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        _spawners = FillSpawners();
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
        _spawners[spawnerIndex].SpawnEnemy();
    }

    private List<Spawner> FillSpawners()
    {
        List<Spawner> spawners = new List<Spawner>();

        for (int i = 0; i < _points.Length; i++)
        {
            var spawner = Instantiate(_spawnerTemplate, _points[i]);
            spawner.Init(_enemiesTemplates[i], _targets[i]);
            spawners.Add(spawner);
        }

        return spawners;
    }
}
