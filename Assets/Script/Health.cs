using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealthPoint;
    public UnityEvent onDie;
    public UnityEvent<int, int> onHealthChanged;
    public UnityEvent onTakeDamage;

    private int _healthPointValue;
    public int HealthPoint
    {
        get => _healthPointValue;
        set
        {
            _healthPointValue = value;
            onHealthChanged.Invoke(_healthPointValue, maxHealthPoint);
        }
    }
    private bool IsDead => HealthPoint <= 0;
    private void Start()
    {
        HealthPoint = maxHealthPoint;
    }
    public void TakeDamage(int damage)
    {
        if (IsDead) return;
        HealthPoint -= damage;
        onTakeDamage.Invoke();
        if(IsDead)
        {
            Die();
        }
    }
    private void Die()
    {
        onDie.Invoke();
    }
        
}
