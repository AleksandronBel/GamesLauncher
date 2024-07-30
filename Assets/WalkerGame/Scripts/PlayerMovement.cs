using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator _animator;

    [SerializeField] float _movementSpeed = 4f;
    [SerializeField] float _rotationSpeed = 180f;

    [SerializeField] Vector2 _length;
    [SerializeField] Vector2 _width;

    void Update()
    {
        Move();
        LimitMovement();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 movePlayer = new Vector3(0, 0, v) * _movementSpeed * Time.deltaTime;
        Vector3 rotatePlayer = new Vector3(0, h, 0) * _rotationSpeed * Time.deltaTime;

        transform.Rotate(rotatePlayer);
        transform.Translate(movePlayer);

        _animator.SetFloat("MovementX", v);

    }

    void LimitMovement()
    {
        float clampedX = Mathf.Clamp(transform.position.x, _length.x, _length.y);
        float clampedZ = Mathf.Clamp(transform.position.z, _width.x, _width.y);
        transform.position = new Vector3(clampedX, transform.position.y, clampedZ);
    }
}
