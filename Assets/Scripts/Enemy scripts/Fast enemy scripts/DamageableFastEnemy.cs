using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Serialization;

public class DamageableFastEnemy : MonoBehaviour, IDamageable
{
    public int Health => health;
    public event Action<int> DamageApplied;
    [SerializeField] private int health;
    
    public void ApplyDamage(int amount)
    {
        if (amount < 0) return;

        health -= amount;
        
        if(health <= 0)
            Die();
        DamageApplied?.Invoke(amount);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
