using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(Transform))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _userInput;
    private SpriteRenderer _renderer;
    private Animator _animator;
    private Rigidbody2D _rb;
    private bool _isGrounded;

    private const string AnimationRun = "isRun";
    private const string AnimationJump = "isJump";

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _userInput = Input.GetAxis("Horizontal");

        if (_userInput > 0)
        {
            gameObject.transform.Translate(_speed * _userInput * Time.deltaTime, 0, 0);
            _renderer.flipX = false;
            _animator.SetBool(AnimationRun, true);
        }
        else if (_userInput < 0)
        {
            gameObject.transform.Translate(_speed * _userInput * Time.deltaTime, 0, 0);
            _renderer.flipX = true;
            _animator.SetBool(AnimationRun, true);
        }
        else
        {
            _animator.SetBool(AnimationRun, false);
        }

        if (Input.GetAxis("Jump") > 0 && _isGrounded)
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode2D.Impulse);
            _animator.SetBool(AnimationJump, true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = true;
            _animator.SetBool(AnimationJump, false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Ground>(out Ground ground))
        {
            _isGrounded = false;
        }
    }
}