using System;
using Controller;
using Flyweight;
using UnityEngine;

namespace Entities.Turrets
{
    public class GranadeBullet : Bullet
    {
        private GranadeBulletStat _stats;
        protected override BulletStat Stats() => GranadeBulletStats;
        private GranadeBulletStat GranadeBulletStats => _stats ??= GetComponent<StatSupplier>().GetStat<GranadeBulletStat>();

        protected override void BeforeDestroy()
        {
            base.BeforeDestroy();
            Explode();
        }

        protected override void Travel()
        {
        }
        
        public new void OnTriggerEnter(Collider otherCollider)
        {
            base.OnTriggerEnter(otherCollider);
            if (GranadeBulletStats.GroundLayer == otherCollider.gameObject.layer)
            {
                Explode();
                SelfDestroy();
            }
            
        }

        private void Explode()
        {

            Collider[] colliders = Physics.OverlapSphere(transform.position, _stats.Radius);
            foreach (Collider collider in colliders)
            {   
                if (LayerTarget.Contains(collider.gameObject.layer)) {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddExplosionForce(_stats.Force, transform.position, _stats.Radius);
                    }
                    var damageable = collider.GetComponent<IDamageable>();
                    damageable?.TakeDamage(_stats.ExplosionDamage);
                }
            }
        }
    }
}