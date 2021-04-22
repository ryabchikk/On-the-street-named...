﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Damageable
{
    [SerializeField] private float distance;
    [SerializeField] private float sqrRadius;
    [SerializeField] private float sqrAttackDistance;
    [SerializeField] private NavMeshAgent nav;
    [SerializeField] private int health;
    public override int Health => health;
    public override event Action<int> DamageApplied; 
    private Player _player;
    private Transform _enemy;
    private bool _isHitCooldown;
    private Transform _playerTransform;
    private Vector3 _defaultPosition;
    private void Start()
    {
        _player = Player.player;
        _playerTransform = _player.gameObject.transform;
        _defaultPosition = transform.position;
    }
    
    private void Update()
    {
        if (_isHitCooldown) 
        {
            return;
        }
        distance = (transform.position - _playerTransform.position).sqrMagnitude;
        if (distance > sqrRadius)
        {
            nav.SetDestination(_defaultPosition);
        }
        else 
        {
            nav.enabled = true;
            nav.SetDestination(_playerTransform.position);
        }
        if (distance < sqrAttackDistance) 
        {   
            nav.SetDestination(transform.position);
            StartCoroutine(nameof(Hit));
        } 
    }
    
    public override void ApplyDamage(int amount)
    {
        if (amount < 0) return;
        
        health -= amount;

        if (health <= 0)
            Die();
        
        DamageApplied?.Invoke(amount);
    }

    public override void Die()
    {
        Destroy(gameObject);
    }
    
    private IEnumerator Hit()
    {
        _isHitCooldown = true;
        _player.ApplyDamage(1);
        yield return new WaitForSeconds(5);
        _isHitCooldown = false;
    }
}
