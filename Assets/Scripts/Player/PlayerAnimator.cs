using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void StartIdle()
    {
        _animator.SetBool("IsIdling", true);
    }

    public void StopIdle()
    {
        _animator.SetBool("IsIdling", false);
    }

    public void StartWalk()
    {
        _animator.SetBool("IsWalking", true);
    }

    public void StopWalk()
    {
        _animator.SetBool("IsWalking", false);
    }

    public void StartJump()
    {
        _animator.SetBool("IsJumping", true);
    }

    public void StopJump()
    {
        _animator.SetBool("IsJumping", false);
    }

    public void StartFall()
    {
        _animator.SetBool("IsFalling", true);
    }

    public void StopFall()
    {
        _animator.SetBool("IsFalling", false);
    }
}
