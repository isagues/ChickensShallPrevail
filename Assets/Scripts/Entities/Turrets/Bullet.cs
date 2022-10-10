using System.Collections.Generic;
using Flyweight;
using Interface;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public abstract class Bullet : MonoBehaviour, IBullet
    {
        protected abstract BulletStat Stats();
        public int Damage => Stats().Damage;
        public float LifeTime => Stats().LifeTime;
        public List<int> LayerTarget => Stats().LayerTarget;
        protected IAutoMove AutoMove { get; private set; }

        protected float _currentLifeTime;

        protected virtual void Awake()
        {
            AutoMove = GetComponent<IAutoMove>();
            _currentLifeTime = LifeTime;
        }

        public void OnTriggerEnter(Collider otherCollider)
        {
            if (!LayerTarget.Contains(otherCollider.gameObject.layer)) return;

            var damageable = otherCollider.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);

            Destroy(gameObject);
        }

        protected void UpdateLifetime()
        {
            _currentLifeTime -= Time.deltaTime;
            if (_currentLifeTime <= 0)
            {
                BeforeDestroy();
                Destroy(gameObject);
            }
        }

        protected virtual void BeforeDestroy()
        {
            return;
        }

        protected void Update()
        {
            AutoMove.Travel();
            UpdateLifetime();
        }
    }
}