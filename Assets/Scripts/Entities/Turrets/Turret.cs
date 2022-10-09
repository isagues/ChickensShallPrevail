using System;
using System.Collections.Generic;
using Command;
using Manager;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Collider))]
    public class Turret : MonoBehaviour, ITurret 
    {
        [SerializeField] protected GameObject bulletPrefab;
        private IDamageable _damageable;
        private Collider _collider;
        
        [SerializeField] private List<int> _damageableLayerMask;
        public TurretType TurretType => turretType;
        [SerializeField] private TurretType turretType;
        [SerializeField] private int cost;
        [SerializeField] private float period;
        
        private float _nextShotTime = 0;
    
        #region ACCESORS
        public int Cost => cost;
        public float Period => period;
        public GameObject BulletPrefab => bulletPrefab;
        public IDamageable Damageable => _damageable;
        public Collider Collider => _collider;
        
        private CmdAttack _cmdAttack;
        #endregion
        
        public virtual void Attack()
        {
            var height = _collider.bounds.size.y / 4;
            var t = transform;
            var bullet = Instantiate(bulletPrefab, t.position + Vector3.up * height, t.rotation);
            bullet.name = bulletPrefab.name;
            bullet.transform.parent = transform;
        }

        protected virtual void Start()
        {
            _damageable = GetComponent<IDamageable>();
            _collider = GetComponent<Collider>();
            _cmdAttack = new CmdAttack(this);
        }

        protected virtual void Update()
        {
            if(Time.time > _nextShotTime) {
                _nextShotTime += period;
                EventQueueManager.instance.AddCommand(_cmdAttack);
            }
        }
    }
}
