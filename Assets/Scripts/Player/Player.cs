using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerCombat))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _legs;
    [SerializeField] private Transform _attackPoint;

    private PlayerMover _mover;
    private PlayerCombat _combat;

    public void Init(PlayerStatsConfig playerStatsConfig)
    {
        _mover = GetComponent<PlayerMover>();
        _combat = GetComponent<PlayerCombat>();

        _mover.Init(playerStatsConfig, _legs);
        _combat.Init(playerStatsConfig, _attackPoint);
    }
}
