using Flyweight;
using Manager;
using UnityEngine;

namespace Controller
{
    public class LifeController: MonoBehaviour, IDamageable
    {
        private ILifeControllerStat _stat;
        public float MaxLife => _stat.MaxLife;
        [SerializeField] private float currentLife; //Debug purposes
    
        private void Start()
        {
            _stat = GetComponent<ILifeControllerStat>();
            currentLife = MaxLife;
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
            if(name == "FArm") EventsManager.instance.FarmLifeChange(currentLife, MaxLife);
        }
    }

    public interface ILifeControllerStat
    {
        float MaxLife { get; }
    }
}