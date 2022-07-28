using System;
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
    private List<RaycastHit2D> _raycastHit;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _contactFilter.useTriggers = false;
        _contactFilter.layerMask = _layerMask;
        _contactFilter.useLayerMask = true;
        _raycastHit = new List<RaycastHit2D>();
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
        _raycastHit.Clear();
        _groundNormal = Vector2.zero;
        _direction += Physics2D.gravity * _gravity;
        _direction *= Time.deltaTime;
        _rb.Cast(_direction, _contactFilter, _raycastHit, _direction.magnitude);

        for(int i = 0; i < _raycastHit.Count; i++)
        {
            if (_raycastHit[i].collider.gameObject.GetComponent<Ground>())
            {
                _isGrounded = true;
                _groundNormal = _raycastHit[i].normal;
                break;
            }
        }

        Move();
    }

    private void Move()
    {
        if (true)
        {
            Debug.Log(_direction);
            _direction = _direction - Vector2.Dot(_direction, _groundNormal) * _groundNormal;
            Debug.Log(_direction);
        }
        _rb.MovePosition(_rb.position + _direction);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(_groundNormal.x, _groundNormal.y) * 3);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(_direction.x, _direction.y));
    }
}