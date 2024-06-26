using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform _target;

    public Transform Target => _target;

    public void Init(Transform target)
    {
        _target = target;
    }
}
