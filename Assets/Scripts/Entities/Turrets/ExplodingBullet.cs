using Flyweight;
using UnityEngine;

namespace Entities.Turrets
{
    public class ExplodingBullet : Bullet
    {
        private ExplodingBulletStat _stats;
        protected override BulletStat Stats() => ExplodingStats;
        private ExplodingBulletStat ExplodingStats => _stats ??= GetComponent<StatSupplier>().GetStat<ExplodingBulletStat>();

        private int _explosionsLeft;

        protected override void Awake()
        {
            base.Awake();
            _explosionsLeft = ExplodingStats.ExplosionCount;
        }

        protected override void BeforeDestroy()
        {
            if (_explosionsLeft > 0)
            {
                GenerateBullet(90);
                GenerateBullet(-90);
            }
        }

        private void GenerateBullet(int angle)
        {
            var bullet  = Instantiate(gameObject, transform.position, Quaternion.Euler(angle * Vector3.up) * transform.rotation);
            var expBullet = bullet.GetComponent<ExplodingBullet>();
            expBullet._explosionsLeft = _explosionsLeft - 1;
            expBullet.CurrentLifeTime = ExplodingStats.LifeTime / 2 / (ExplodingStats.ExplosionCount - expBullet._explosionsLeft + 1);
            bullet.SetActive(true);
        }
    }
}