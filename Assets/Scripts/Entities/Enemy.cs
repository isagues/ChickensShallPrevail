using System.Collections.Generic;
using Controller;
using Flyweight;
using Manager;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Enemy: MonoBehaviour, IEnemy
    {
        private EnemyStat _stats;

        private Rigidbody _rigidBody;
        private Collider _collider;
        private IDamageable _damageable;
        private IAutoMove _autoMoveController;

        public int Damage => _stats.Damage;
        public List<int> DamageableLayerMask => _stats.DamageableLayerMask;
        public int TargetLayer => _stats.TargetLayer;
        public Rigidbody Rigidbody => _rigidBody;
        public Collider Collider => _collider;
        public IDamageable Damageable => _damageable;
        public IAutoMove AutoMove => _autoMoveController;

        private void OnCollisionStay(Collision collision)
        {
            int layer = collision.gameObject.layer;
            if (!DamageableLayerMask.Contains(layer) || layer == TargetLayer) return;
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            int layer = other.gameObject.layer;
            if (!DamageableLayerMask.Contains(layer) && layer != TargetLayer) return;
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);
            Destroy(gameObject);
        }

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<EnemyStat>();
            
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _damageable = GetComponent<IDamageable>();
            _autoMoveController = GetComponent<IAutoMove>();

            _rigidBody.useGravity = false;
            // _rigidBody.isKinematic = true;
            _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }
    
        private void Update()
        {
            _autoMoveController.Travel();
        }

        private void OnDestroy()
        {
            EventsManager.instance.EnemyKilled(GetInstanceID());
        }
    }
}
