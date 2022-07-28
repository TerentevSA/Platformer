using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;
    [SerializeField] private float _minGroundNormalY;
    [SerializeField] private LayerMask _layerMask;

    private Vector2 _direction;
    private Vector2 _groundNormal;
    private ContactFilter2D _contactFilter;
    private RaycastHit2D[] _raycastHit;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private const float _shellDistance = 0.01f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _contactFilter.useTriggers = false;
        _contactFilter.layerMask = _layerMask;
        _contactFilter.useLayerMask = true;
        _raycastHit = new RaycastHit2D[16];
    }

    private void Update()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal") * _speed, 0);

        if (Input.GetKey(KeyCode.Space) && _isGrounded)
            _direction.y = _jumpForce;
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
        Move();
    }

    private Vector2 GetDirectionAlongSurface(Vector2 direction)
    {

    }

    private void Move()
    {
        Vector2 velocity;

        velocity = GetDirectionAlongSurface(_direction.normalized);
        velocity = velocity * _speed * Time.deltaTime;
        _rb.position += velocity;
    }
}