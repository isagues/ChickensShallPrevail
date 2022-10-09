using System.Collections.Generic;
using Manager;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider))]
    public class Enemy: MonoBehaviour, IEnemy
    {
    
        [SerializeField] private int damage = 1;
        [SerializeField] private List<int> damageableLayerMask;

        private Rigidbody _rigidBody;
        private Collider _collider;
        private IDamageable _damageable;
        private IAutoMove _autoMoveController;
    
    
        #region ACCESORS
        public Rigidbody Rigidbody => _rigidBody;
        public Collider Collider => _collider;
        public IDamageable Damageable => _damageable;
        public int Damage => damage;
        public IAutoMove AutoMove => _autoMoveController;
        #endregion

        private void OnCollisionStay(Collision collision)
        {
            int layer = collision.gameObject.layer;
            if (!damageableLayerMask.Contains(layer) || layer == 14) return;
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);
        }

        private void OnTriggerEnter(Collider other)
        {
            int layer = other.gameObject.layer;
            if (!damageableLayerMask.Contains(layer) && layer != 14) return;
            var damageable = other.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage * 3);
            Destroy(gameObject);
        }

        private void Start()
        {
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
