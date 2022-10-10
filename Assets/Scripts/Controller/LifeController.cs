using System;
using Flyweight;
using Manager;
using UnityEngine;

namespace Controller
{
    public class LifeController: MonoBehaviour, IDamageable
    {
        private ILifeControllerStat _stats;
        public float MaxLife => _stats.MaxLife;
        [SerializeField] private float currentLife; //Debug purposes

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<ILifeControllerStat>();
            currentLife = MaxLife;
        }
    
        private void Start()
        {
            UI_Updater();
        }

        public void TakeDamage(float damage)
        {
            currentLife -= damage;
            UI_Updater();

            if (currentLife <= 0)
            {
                Die();
            }
        }

        public void Die()
        { 
            Destroy(gameObject);
        }
        
        public void UI_Updater() 
        { 
            if(name == "Farm") EventsManager.instance.FarmLifeChange(currentLife, MaxLife);
        }
    }

    public interface ILifeControllerStat
    {
        float MaxLife { get; }
    }
}