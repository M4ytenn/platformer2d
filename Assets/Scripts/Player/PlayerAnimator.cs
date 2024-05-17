using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private PlayerMover _mover;
    [SerializeField] private PlayerCombat _combat;

    private void Update()
    {
        _animator.SetFloat("VelocityX", _mover.Rigidbody.velocity.x);
        _animator.SetFloat("VelocityY", _mover.Rigidbody.velocity.y);
        _animator.SetBool("IsAttacking", _combat.IsAttacking);
    }
}
