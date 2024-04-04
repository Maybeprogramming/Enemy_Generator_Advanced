using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rotator))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * _speed);
    }
}
