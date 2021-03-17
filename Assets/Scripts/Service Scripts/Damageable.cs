using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public abstract int Health { get; }
    public abstract event Action<int> DamageApplied;
    public abstract void ApplyDamage(int amount);
    public abstract void Die();
}
