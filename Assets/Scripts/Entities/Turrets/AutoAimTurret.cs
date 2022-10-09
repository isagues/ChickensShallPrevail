using System;
using UnityEngine;
using Utils;

namespace Entities.Turrets
{
    public class AutoAimTurret : Turret
    {
        private int counter = 0;
        protected override void Start()
        {
            base.Start();

            Debug.Log(_bulletPrefab.GetComponent<IBullet>().GetType());
            if (_bulletPrefab.GetComponent<IBullet>().GetType() != typeof(LockedOnBullet))
                throw new ArgumentException("Invalid bullet type. Required LockedOnBullet");

        }
        
        public override void Attack()
        {
            float height = _collider.bounds.size.y / 4;
            var bullet = Instantiate(_bulletPrefab, transform.position + Vector3.up * height, transform.rotation);
            bullet.name = $"LockOn Bala Turret {counter++}";
        }
    }
}