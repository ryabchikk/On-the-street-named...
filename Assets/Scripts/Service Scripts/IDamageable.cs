using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    public abstract int Health { get; }
    public virtual event Action<int> DamageApplied;
    public abstract void ApplyDamage(int amount);
    public abstract void Die();
}
