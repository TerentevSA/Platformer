using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _minGroundNormalY;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity;

    private Vector2 _direction;
    private Vector2 _surfaceDirection;
    private Vector2 _velocity;
    private Vector2 _normal;
    private Rigidbody2D _rb;
    private Collision2D _lastGroundCollision;
    private bool _isGrounded;

    private void Start()
    {
        _normal = Vector2.up;
        _direction = Vector2.zero;
        _rb = GetComponent<Rigidbody2D>();
        _isGrounded = false;
    }

    private void FixedUpdate()
    {
        _direction.x = Input.GetAxisRaw("Horizontal");
        _surfaceDirection = _direction - Vector2.Dot(_direction, _normal) * _normal;
        _velocity = _surfaceDirection * _speed * Time.deltaTime;

        if(_isGrounded == false)
        {
            _velocity.y = Physics2D.gravity.y * _gravity * Time.deltaTime;
        }

        _rb.position = _rb.position + _velocity;

        if(_isGrounded && Input.GetKey(KeyCode.Space))
        {
            _rb.AddForce(new Vector2(0, _jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.contacts[0].normal;

        if (collisionNormal.y > _minGroundNormalY)
        {
            _normal = collisionNormal;
            _lastGroundCollision = collision;
            Debug.Log("asdasd");
            _isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision == _lastGroundCollision)
        {
            Debug.Log("asdasd");
            _isGrounded = false;
        }
    }
}