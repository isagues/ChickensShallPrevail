using Flyweight;
using UnityEngine;

namespace Entities.Turrets
{
    public class PropagatingBullet : Bullet
    {
        private PropagatingBulletStat _stats;
        protected override BulletStat Stats() => PropagatingStats;
        private PropagatingBulletStat PropagatingStats => _stats ??= GetComponent<StatSupplier>().GetStat<PropagatingBulletStat>();

        private int _explosionsLeft;

        protected override void Awake()
        {
            base.Awake();
            _explosionsLeft = PropagatingStats.ExplosionCount;
        }

        protected override void BeforeDestroy()
        {
            base.BeforeDestroy();
            if (_explosionsLeft > 0)
            {
                GenerateBullet(90);
                GenerateBullet(-90);
            }
        }

        private void GenerateBullet(int angle)
        {
            var bullet  = Instantiate(gameObject, transform.position, Quaternion.Euler(angle * Vector3.up) * transform.rotation);
            var expBullet = bullet.GetComponent<PropagatingBullet>();
            expBullet._explosionsLeft = _explosionsLeft - 1;
            expBullet.CurrentLifeTime = PropagatingStats.LifeTime / 2 / (PropagatingStats.ExplosionCount - expBullet._explosionsLeft + 1);
            bullet.SetActive(true);
        }
    }
}