using System.Collections.Generic;
using Flyweight;
using Manager;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Enemy: MonoBehaviour, IEnemy
    {
        private EnemyStat _stats;
        private EnemyStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<EnemyStat>();

        public int Damage => Stats.Damage;
        public List<int> DamageableLayerMask => Stats.DamageableLayerMask;
        public int TargetLayer => Stats.TargetLayer;
        
        private Rigidbody _rigidBody;
        private Collider _collider;
        private Animator _animator;
        private IDamageable _damageable;
        private IAutoMove _autoMoveController;
        private float _attackTimer;

        public Rigidbody Rigidbody => _rigidBody;
        public Collider Collider => _collider;
        public IDamageable Damageable => _damageable;
        public IAutoMove AutoMove => _autoMoveController;

        private bool _attacking = false;

        private void OnCollisionStay(Collision collision)
        {
            int layer = collision.gameObject.layer;
            if (!DamageableLayerMask.Contains(layer) || layer == TargetLayer) return;
            _attackTimer = Time.time + Stats.AttackTime;
            _animator.SetTrigger("Attack");
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
            _rigidBody = GetComponent<Rigidbody>();
            _collider = GetComponent<Collider>();
            _damageable = GetComponent<IDamageable>();
            _animator = GetComponent<Animator>();
            _autoMoveController = GetComponent<IAutoMove>();
            _attackTimer = Time.time;
            _rigidBody.useGravity = false;
            // _rigidBody.isKinematic = true;
            _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }
    
        private void Update()
        {
            if (AutoMove.isBoosted())
            {
                _animator.SetTrigger("Boost");
            }
            if (Time.time > _attackTimer)
            {
                _autoMoveController.Travel();
            }
        }

        private void OnDestroy()
        {
            EventsManager.instance.EnemyKilled(GetInstanceID());
        }
    }
}
