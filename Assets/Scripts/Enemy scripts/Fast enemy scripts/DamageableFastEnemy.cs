using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class DamageableFastEnemy : Damageable
{
    public override int Health => health;
    public override event Action<int> DamageApplied;
    [SerializeField] private int health;
    
    public override void ApplyDamage(int amount)
    {
        if (amount < 0) return;

        health -= amount;
        
        if(health <= 0)
            Die();
        DamageApplied?.Invoke(amount);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
}
