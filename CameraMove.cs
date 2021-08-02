using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform _target;       // Transform component of target
    private Vector3 _position;      // New Position
    public float _speed = 4f;       // Speed of camera move

    /// <summary>
    /// Initialize the fields
    /// </summary>
    void Start()
    {
        _position = _target.InverseTransformPoint(transform.position);
    }

    /// <summary>
    /// Move camera
    /// </summary>
    void Update()
    {
        var currentPosition = _target.TransformPoint(_position);
        transform.position = Vector3.Lerp(transform.position, currentPosition, _speed * Time.deltaTime);
        var currentRotation = Quaternion.LookRotation(_target.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentRotation, _speed * Time.deltaTime);
    }
}
