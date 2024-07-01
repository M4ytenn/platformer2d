using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;

    private Transform _legs;

    private float _speed;
    private float _jumpPower;
    private LayerMask _groundMask;
    private float _legsRadius;

    private bool _onGround;

    public Rigidbody2D Rigidbody => _rigidbody;

    public void Init(PlayerStatsConfig playerStatsConfig, Transform legs)
    {
        _legs = legs;

        _speed = playerStatsConfig.MovementConfig.Speed;
        _jumpPower = playerStatsConfig.MovementConfig.JumpPower;
        _groundMask = playerStatsConfig.MovementConfig.GroundMask;
        _legsRadius = playerStatsConfig.MovementConfig.LegsRadius;
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

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        _rigidbody.velocity = new Vector2(horizontalInput * _speed, _rigidbody.velocity.y);
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
}
