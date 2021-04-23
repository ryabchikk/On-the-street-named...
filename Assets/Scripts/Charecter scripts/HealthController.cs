﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour, IDamageable
{
    public int Health => _health;
    public event Action<int> DamageApplied;
    [SerializeField] private Image[] Lives;
    [SerializeField] private GameObject deathScreen;
    private int _health = 3;
    private int _countLive;

    private void Start()
    {
        _countLive = Lives.Length - 1;
    }

    public void ApplyDamage(int amount)
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

    public void Die()
    {
        Player.player.DeactivateShooting(false);
        var cc = GetComponent<CharacterController>();
        cc.detectCollisions = false;
        cc.enabled = false;
        GetComponentInChildren<ParticleSystem>().Stop();
        if(GetComponent<CapsuleCollider>() == null)
        {
            gameObject.AddComponent<CapsuleCollider>();
            var rb = gameObject.AddComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 20f, ForceMode.Impulse);
        }
        deathScreen.SetActive(true);
    }
}

