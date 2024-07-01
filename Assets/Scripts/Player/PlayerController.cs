using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private PlayerStatsConfig _statsConfig;
    [SerializeField] private PlayerAnimator _animator;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _legs;

    private PlayerInput _input;
    private PlayerStateMachine _stateMachine;
    private float _legsRadius = 0.1f;

    public PlayerInput Input => _input;
    public Rigidbody2D Rigidbody => _rigidbody;
    public PlayerStatsConfig StatsConfig => _statsConfig;
    public PlayerAnimator Animator => _animator;

    public bool OnGround { get; private set; }

    [Inject]
    public void Construct(PlayerInput input)
    {
        _input = input;
        _stateMachine = new PlayerStateMachine(this);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    private void Update()
    {
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        OnGround = Physics2D.OverlapCircle(_legs.position, _legsRadius, _groundMask);
    }
}