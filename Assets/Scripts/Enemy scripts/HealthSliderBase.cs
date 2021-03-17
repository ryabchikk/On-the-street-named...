using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class HealthSliderBase : MonoBehaviour
{
    [SerializeField] protected Slider slider;
    protected int maxHealth;

    private void Start()
    {
        slider.value = 1;
    }

    public void Init(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public abstract void Change(int amount);
}
