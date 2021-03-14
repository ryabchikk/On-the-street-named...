using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float sqrRadius;
    [SerializeField] private float sqrAttackDistance;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private bool isHitCooldown;
    [SerializeField] private NavMeshAgent nav;
    private Player _player;
    private Transform _enemy;

    private void Start()
    {
        _player = Player.player;
    }
    
    private void Update()
    {
        distance = (transform.position - playerTransform.position).sqrMagnitude;
        if (distance > sqrRadius)
        {
            nav.enabled = false;
        }
        else 
        {
            nav.enabled = true;
            nav.SetDestination(playerTransform.position);
        }
        if (distance < sqrAttackDistance && !isHitCooldown) 
        {
            nav.enabled = false;
            StartCoroutine(nameof(Hit));
        } 
    }
    
    private IEnumerator Hit()
    {
        isHitCooldown = true;
        _player.ApplyDamage(1);
        yield return new WaitForSeconds(5);
        isHitCooldown = false;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
