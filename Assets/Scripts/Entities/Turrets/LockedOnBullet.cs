using System;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using Utils;

namespace Entities.Turrets
{
    public class LockedOnBullet : Bullet
    {
        [SerializeField] private GameObject target;
        private OnDestroyPublisher onDestroyPublisher;

        protected override void Start()
        {
            base.Start();
            target = VectorUtils.FindClosestByTag(transform.position, "Enemy");
            if (target is null)
            {
                Destroy(gameObject);
                return;
            }
            
            onDestroyPublisher = OnDestroyPublisher.AttachPublisher(target);
            onDestroyPublisher.OnDestroyAction += SelfDestruct;
        }

        public void OnDestroy()
        {
            onDestroyPublisher.OnDestroyAction -= SelfDestruct;
        }

        private void SelfDestruct()
        {
            Destroy(gameObject);
        }

        protected override void Update()
        {
            // if (target == null) Destroy(this.gameObject);
            _autoMoveController.TravelToTarget(target.transform.position);
        }
    }
}