using System;
using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/Create PlayerStatsConfig", fileName = "PlayerStatsConfig", order = 54)]
public class PlayerStatsConfig : ScriptableObject
{
    [SerializeField] private PlayerCombatConfig _combatConfig;
    [SerializeField] private PlayerMovementConfig _movementConfig;

    public PlayerCombatConfig CombatConfig => _combatConfig;
    public PlayerMovementConfig MovementConfig => _movementConfig;
}

[Serializable]
public class PlayerCombatConfig
{
    [SerializeField] private float _attackRange = 1;
    [SerializeField] private float _damage = 1;

    public float AttackRange => _attackRange;
    public float Damage => _damage;
}

[Serializable]
public class PlayerMovementConfig
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 5;
    [SerializeField] private float _legsRadius = 0.1f;
    [SerializeField] private LayerMask _groundMask;

    public float Speed => _speed;
    public float JumpPower => _jumpPower;
    public float LegsRadius => _legsRadius; 
    public LayerMask GroundMask => _groundMask;
}
