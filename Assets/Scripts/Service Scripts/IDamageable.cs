using System;
using UnityEngine;

public interface IDamageable
{
    int Health { get; }
    event Action<int> DamageApplied;
    void ApplyDamage(int amount);
    void Die();
}
