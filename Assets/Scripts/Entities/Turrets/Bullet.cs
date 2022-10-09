using System.Collections.Generic;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
    public class Bullet: MonoBehaviour, IBullet
    {
        public int Damage => damage;
        [SerializeField] private int damage = 10;
    
        public float LifeTime => lifeTime;
        [SerializeField] private float lifeTime = 5;

        public Rigidbody Rigidbody { get; private set; }
        public Collider Collider { get; private set; }
        protected IAutoMove AutoMove { get; private set; }

        [SerializeField] private List<int> layerTarget;
    
        protected virtual void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
            Collider = GetComponent<Collider>();
            AutoMove = GetComponent<IAutoMove>();

            Collider.isTrigger = true;
            Rigidbody.useGravity = false;
            Rigidbody.isKinematic = true; // Inafectable
            Rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        public void OnTriggerEnter(Collider otherCollider)
        {
            if (!layerTarget.Contains(otherCollider.gameObject.layer)) return;
        
            var damageable = otherCollider.GetComponent<IDamageable>();
            damageable?.TakeDamage(damage);
        
            Destroy(gameObject);
        }

        protected void UpdateLifetime()
        {
            lifeTime -= Time.deltaTime;
            if(lifeTime <= 0) Destroy(gameObject);
        }

        protected void Update()
        {
            AutoMove.Travel();
            UpdateLifetime();
        }
    }
}