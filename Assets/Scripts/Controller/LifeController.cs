using Flyweight;
using Manager;
using UnityEngine;

namespace Controller
{
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

            if (_currentLife <= 0)
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
            if(name == "FArm") EventsManager.instance.FarmLifeChange(_currentLife, MaxLife);
        }
    }
}