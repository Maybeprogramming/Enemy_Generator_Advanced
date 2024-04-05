using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Update()
    {
        Move();
        RemoveByFinished();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _enemy.Target.position, Time.deltaTime * _speed);
        transform.LookAt(_enemy.Target);
    }

    private void RemoveByFinished()
    {
        if (transform.position == _enemy.Target.position)
        {
            Destroy(gameObject);
        }
    }
}
