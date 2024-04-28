using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Transform _attackPoint;

    private float _attackRange;
    private float _damage;

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
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange);

            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent(out Health health))
                {
                    health.ApplyDamage(_damage);
                }
            }
        }
    }
}
