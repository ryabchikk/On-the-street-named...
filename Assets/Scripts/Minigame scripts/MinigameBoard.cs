using System;
using UnityEngine;

public abstract class MinigameBoard : MonoBehaviour
{
    private Player _player;
    
    protected void Awake()
    {
        _player = Player.player;
        _player.DeactivateShooting();
    }

    protected void OnDestroy()
    {
        _player.ActivateShooting();
    }
}