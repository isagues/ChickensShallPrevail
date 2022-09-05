using System;
using UnityEngine;

public class LifeController: MonoBehaviour, IDamageable
{
    public float MaxLife => _maxLife;
    [SerializeField] private float _maxLife;
    [SerializeField] private float _currentLife;
    
    private void Start()
    {
        _currentLife = _maxLife;
    }

    public void TakeDamage(float damage)
    {
        _currentLife -= damage;
        if(_currentLife <= 0) Die();
    }

    public void Die() => Destroy(this.gameObject); // si es this saca solo el componente de este script.
}