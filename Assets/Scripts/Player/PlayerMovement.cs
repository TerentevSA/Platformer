using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minGroundNormalY;
    [SerializeField] private float _gravity;
    [SerializeField] private float _speed;
    [SerializeField] private LayerMask _layerMask;

    private Vector2 _direction;
    private Vector2 _normal;
    private Rigidbody2D _rb;
    private List<RaycastHit2D> _raycastHit;
    private ContactFilter2D _contactFilter;
    private bool _isGrounded;
    private bool _canSecondJump;
    private float _distance;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _contactFilter.useTriggers = false;
        _contactFilter.SetLayerMask(_layerMask);
        _contactFilter.useLayerMask = true;
        _canSecondJump = true;
    }

    private void FixedUpdate()
    {
        _isGrounded = false;
        _direction.x += Input.GetAxisRaw("Horizontal") * _speed * Time.deltaTime;
        _distance = _direction.magnitude;
    }
}