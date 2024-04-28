using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;

    private Rigidbody2D _rigidbody;
    private float _legsRadius = 0.1f;
    private bool _onGround;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void FixedUpdate()
    {
        _onGround = CheckOnGround();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _onGround)
        {
            _rigidbody.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private bool CheckOnGround()
    {
        return Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
    }
}
