using System;
using System.Collections.Generic;
using Command;
using Interface;
using Manager;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Collider))]
    public class Turret : MonoBehaviour, ITurret
    {
        [SerializeField] protected GameObject bulletPrefab;
        private IDamageable _damageable;
        private Collider _collider;
        private IListenable _listenable;
        
        [SerializeField] private List<int> _damageableLayerMask;

        [SerializeField] private float period;
        
        private float _nextShotTime;
    
        #region ACCESORS
        public float Period => period;
        public GameObject BulletPrefab => bulletPrefab;
        public IDamageable Damageable => _damageable;
        public Collider Collider => _collider;
        public IListenable Listenable => _listenable;
        
        private CmdAttack _cmdAttack;
        #endregion
        
        public virtual void Attack()
        {
            var height = _collider.bounds.size.y / 4;
            var t = transform;
            var bullet = Instantiate(bulletPrefab, t.position + Vector3.up * height, t.rotation);
            bullet.name = bulletPrefab.name;
            bullet.transform.parent = transform;
            _listenable.Play();
        }

        protected virtual void Start()
        {
            _damageable = GetComponent<IDamageable>();
            _collider = GetComponent<Collider>();
            _listenable = GetComponent<IListenable>();
            _cmdAttack = new CmdAttack(this);
            _nextShotTime = Time.time;
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
