using System.Collections.Generic;
using Flyweight;
using Interface;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public class Bullet: MonoBehaviour, IBullet
    {
        private BulletStat _stats;
        private BulletStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<BulletStat>();
        
        public int Damage => Stats.Damage;
        public float LifeTime => Stats.LifeTime;
        public List<int> LayerTarget => Stats.LayerTarget;

        public Rigidbody Rigidbody { get; private set; }
        public Collider Collider { get; private set; }
        protected IAutoMove AutoMove { get; private set; }
        
        private float _currentLifeTime;

        protected virtual void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            AutoMove = GetComponent<IAutoMove>();

            _currentLifeTime = LifeTime;
            Collider.isTrigger = true;
            Rigidbody.useGravity = false;
            Rigidbody.isKinematic = true; // Inafectable
            Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
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
            if(_currentLifeTime <= 0) Destroy(gameObject);
        }

        protected void Update()
        {
            AutoMove.Travel();
            UpdateLifetime();
        }
    }
}