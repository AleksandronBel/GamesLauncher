using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform _targetToFollow { get; set; }
    [SerializeField] float _lerpRate;

    [SerializeField] Vector2 _length;
    [SerializeField] Vector2 _width;

    void Start()
    {
        _targetToFollow = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update()
    {
        Vector3 targetPosition = Vector3.Lerp(transform.position, _targetToFollow.position, Time.deltaTime * _lerpRate);

        float clampedX = Mathf.Clamp(targetPosition.x, _length.x, _length.y);
        float clampedZ = Mathf.Clamp(targetPosition.z, _width.x, _width.y);

        transform.position = new Vector3(clampedX, targetPosition.y, clampedZ);
    }
}
