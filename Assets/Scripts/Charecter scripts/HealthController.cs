using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private int _health = 3;
    [SerializeField] public Image[] Lives;
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

    private void Die() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}

