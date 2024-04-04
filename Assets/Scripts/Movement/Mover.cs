using System;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Enemy))]
public class Mover : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _speed;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Move();
        RemoveByTargetFinished();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _enemy.Target.position, Time.deltaTime * _speed);
        transform.LookAt(_enemy.Target);
    }

    private void RemoveByTargetFinished()
    {
        if (transform.position == _enemy.Target.position)
        {
            Destroy(gameObject);
        }
    }
}
