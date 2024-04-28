using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    private const string PlayerStatsConfigPath = "StaticData/PlayerStatsConfig";

    [SerializeField] private Player _player;

    private void Awake()
    {
        PlayerStatsConfig playerStatsConfig = Resources.Load<PlayerStatsConfig>(PlayerStatsConfigPath);
        _player.Init(playerStatsConfig);
    }
}
