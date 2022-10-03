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
        UI_Updater();
    }

    public void TakeDamage(float damage)
    {
        _currentLife -= damage;
        UI_Updater();

        if (IsDead())
        {
            if (name == "Sir Pipo") EventsManager.instance.EventGameOver(false);
            Die();
        }
    }

    public void Die()
    { 
        Destroy(this.gameObject);
        // si es this saca solo el componente de este script.
    }
    
    private bool IsDead() => _currentLife <= 0;

    private void OnDestroy()
    {
        if (name == "Character") EventsManager.instance.EventGameOver(false);
    }
    
    public void UI_Updater() 
    { 
        if(name == "Sir Pipo") EventsManager.instance.CharacterLifeChange(_currentLife, MaxLife);
    }
}