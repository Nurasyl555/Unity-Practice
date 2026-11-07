using System;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 1;

    private int _health;

    private void Awake()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new Exception("Damage is negative");

        _health -= damage;
        if (_health <= 0)
            Die();
    }

    // 1
    public void Heal(int amount)
    {
        if (amount < 0)
            throw new Exception("Heal amount is negative");

        _health += amount;

        
        if (_health > _maxHealth)
            _health = _maxHealth;

        Debug.Log($"Player healed! Current HP: {_health}");
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}