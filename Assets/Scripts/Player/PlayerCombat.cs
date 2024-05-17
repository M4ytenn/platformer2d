using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;

    private float _attackRange;
    private float _damage;

    public bool IsAttacking { get; private set; } = false;

    public void Init(PlayerStatsConfig playerStatsConfig, Transform attackPoint)
    {
        _attackPoint = attackPoint;
        _attackRange = playerStatsConfig.CombatConfig.AttackRange;
        _damage = playerStatsConfig.CombatConfig.Damage;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (IsAttacking == false)
                StartAttack();
        }
    }

    public void PerformAttack()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out Health health))
            {
                health.ApplyDamage(_damage);
            }
        }
    }

    public void EndAttack() => IsAttacking = false;

    private void StartAttack() => IsAttacking = true;
}
