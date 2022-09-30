using System;
using Flyweight;
using Manager;
using UnityEngine;

public class LifeController: MonoBehaviour, IDamageable
{
    [SerializeField] private ActorStats _actorStats;
    public float MaxLife => _actorStats.MaxLife;
    [SerializeField] private float _currentLife;
    
    private void Start()
    {
        _currentLife = MaxLife;
    }

    public void TakeDamage(float damage)
    {
        _currentLife -= damage;
        if(_currentLife <= 0) Die();
    }

    public void Die()
    { 
        Destroy(this.gameObject);
        // si es this saca solo el componente de este script.
    }

    private void OnDestroy()
    {
        if (name == "Character") EventsManager.instance.EventGameOver(false);
    }
}