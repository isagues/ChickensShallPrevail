using Flyweight;
using Manager;
using UnityEngine;

namespace Controller
{
    public class LifeController: MonoBehaviour, IDamageable
    {
        private ILifeControllerStat _stats;
        private ILifeControllerStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<ILifeControllerStat>();
        
        public float MaxLife => Stats.MaxLife;
        
        [SerializeField] private float currentLife; //Debug purposes

        private void Awake()
        {
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