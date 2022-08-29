using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private Vector2 _velocity;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _velocity = new Vector2(_speed * Input.GetAxisRaw("Horizontal") * Time.deltaTime, 0);
    }
}