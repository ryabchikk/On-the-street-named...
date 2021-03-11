using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Image[] Lives;
    [SerializeField] private GameObject deathScreen;
    private int _health = 3;
    private int _countLive;

    private void Start()
    {
        _countLive = Lives.Length - 1;
    }

    public void AddDamage(int amount)
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
        }
            
    }
    
    public void AddHeal(int amount)
    {
        if (_health + amount <= 3)
            _health += amount;
    }

    private void Die()
    {
        Player.player.DeactivateShooting(false);
        deathScreen.SetActive(true);
    }
}

