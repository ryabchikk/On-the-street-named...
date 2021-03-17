using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : Damageable
{
    public override int Health => _health;
    public override event Action<int> DamageApplied;
    [SerializeField] private Image[] Lives;
    [SerializeField] private GameObject deathScreen;
    private int _health = 3;
    private int _countLive;

    private void Start()
    {
        _countLive = Lives.Length - 1;
    }

    public override void ApplyDamage(int amount)
    {
        if (_health - amount <= 0) 
        { 
            Die();
        }
        else 
        {
            _health -= 1;
            Lives[_countLive].enabled = false;
            _countLive--;
            DamageApplied?.Invoke(amount);
        }
            
    }

    public override void Die()
    {
        Player.player.DeactivateShooting(false);
        deathScreen.SetActive(true);
    }
}

