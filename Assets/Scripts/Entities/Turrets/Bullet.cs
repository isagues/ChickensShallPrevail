using System.Collections.Generic;
using Flyweight;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public class Bullet: MonoBehaviour, IBullet
    {
        [SerializeField] private BulletStat bulletStat;
        public int Damage => bulletStat.Damage;
        public float LifeTime => bulletStat.LifeTime;

        private float _currentLifeTime;
        public Rigidbody Rigidbody { get; private set; }
        public Collider Collider { get; private set; }
        protected IAutoMove AutoMove { get; private set; }

        [SerializeField] private List<int> layerTarget;
    
        protected virtual void Start()
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
            if (!layerTarget.Contains(otherCollider.gameObject.layer)) return;
        
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