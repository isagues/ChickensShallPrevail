using System.Collections.Generic;
using Flyweight;
using Interface;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        protected abstract BulletStat Stats();
        public int Damage => Stats().Damage;
        public float LifeTime => Stats().LifeTime;
        public GameObject ExplosionPrefab => Stats().Explosion;
        public List<int> LayerTarget => Stats().LayerTarget;
        protected IAutoMove AutoMove { get; private set; }

        protected float CurrentLifeTime;
        protected virtual void Awake()
        {
            AutoMove = GetComponent<IAutoMove>();
            CurrentLifeTime = LifeTime;
        }

        public void OnTriggerEnter(Collider otherCollider)
        {
            calculateDamage(otherCollider);
        }
        //Por que me esta damageando?
        protected void calculateDamage(Collider otherCollider)
        {
            if (!LayerTarget.Contains(otherCollider.gameObject.layer)) return;

            var damageable = otherCollider.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);

            SelfDestroy(); 
        }

        private void SelfDestroy()
        {
            BeforeDestroy();
            Destroy(gameObject);
        }

        protected void UpdateLifetime()
        {
            CurrentLifeTime -= Time.deltaTime;
            if (CurrentLifeTime <= 0)
            {
                SelfDestroy();
            }
        }

        protected virtual void BeforeDestroy()
        {
            Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }

        protected abstract void Travel();

        protected void Update()
        {
            Travel();
            UpdateLifetime();
        }
    }
}