using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private List<Transform> _spawnpoints;
    [SerializeField] private Transform _target;
    [SerializeField] private Enemy[] _enemies;

    public event Action<Enemy> Spawned;

    public Vector3 Target => _target.position;

    private void OnSpawned()
    {
        int pointIndex = new System.Random().Next(0, _spawnpoints.Count);
        Enemy newEnemy = _enemies[new System.Random().Next(0, _enemies.Length)];
        newEnemy.Init(_target);
        newEnemy = Instantiate(newEnemy, _spawnpoints[pointIndex].position, Quaternion.identity);
        Spawned?.Invoke(newEnemy);
    }

    private void OnEnable()
    {
        _timer.Triggered += OnSpawned;
    }

    private void OnDisable()
    {
        _timer.Triggered -= OnSpawned;
    }
}
