using System;
using System.Collections.Generic;
using Command;
using Flyweight;
using Interface;
using Manager;
using UnityEngine;
using Utils;

namespace Entities
{
    [RequireComponent(typeof(IAutoMove))]
    public class SuicideChicken : MonoBehaviour
    {
        private SuicideChickenStat _stats;
        private SuicideChickenStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<SuicideChickenStat>();
        public List<int> LayerTarget => Stats.LayerTarget;
        public IAutoMove AutoMove { get; private set; }

        private GameObject _target;
        private bool _lockOn;
        private OnDestroyPublisher _onDestroyPublisher;


        private void Awake()
        {
            AutoMove = GetComponent<IAutoMove>();
            GameObject _generatorTarget = VectorUtils.FindClosestByTag(transform.position, "Generator");
            transform.LookAt(_generatorTarget.transform);
            checkClosest();
            transform.Rotate(((float)Math.PI) * Vector3.up);
            transform.Rotate(2 * Vector3.up);
        
        }

        private void checkClosest()
        {
            _target = VectorUtils.FindClosestByTag(transform.position, "Enemy");
            if (_target is null)
            {
                _lockOn = false;
            }
            else
            {
                _lockOn = true;
                _onDestroyPublisher = OnDestroyPublisher.AttachPublisher(_target);
                _onDestroyPublisher.OnDestroyAction += LockOff;
            }
        }
        private void LockOff()
        {
            _lockOn = false;
        }
        
        public void OnTriggerEnter(Collider otherCollider)
        {
            if (!LayerTarget.Contains(otherCollider.gameObject.layer)) return;
            Explode();
            SelfDestroy();
        }
        
        private void Explode()
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, Stats.Radius);
            foreach (Collider collider in colliders)
            {   
                if (LayerTarget.Contains(collider.gameObject.layer)) {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(_stats.Force, transform.position, Stats.Force);
                    }
                    var damageable = collider.GetComponent<IDamageable>();
                    damageable?.TakeDamage(_stats.Damage);
                }
            }
        }
        
        protected void SelfDestroy()
        {
            BeforeDestroy();
            Destroy(gameObject);
        }
        
        protected virtual void BeforeDestroy()
        {
            var explosion = Instantiate(Stats.ExplosionPrefab, transform.position, transform.rotation);
            explosion.name = Stats.ExplosionPrefab.name;
            explosion.transform.parent = transform.parent;
        }

        private void Update()
        {
            if (_lockOn)
            {
                _target = VectorUtils.FindClosestByTag(transform.position, "Enemy");
                AutoMove.TravelToTarget(_target.transform.position);
            }
            else
            {  
                AutoMove.Travel();
                checkClosest();
            }
        }

        public void OnDestroy()
        {
            if (_lockOn)
            {
                _onDestroyPublisher.OnDestroyAction -= LockOff;
            }
        }
    }
}