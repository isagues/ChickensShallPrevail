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
                generateBullet(90);
                generateBullet(-90);
            }
            Destroy(gameObject);
        }

        private void generateBullet(int angle)
        {
            var bullet  = Instantiate(gameObject, transform.position, Quaternion.Euler(angle * Vector3.up) * transform.rotation);
            ExplodingBullet expBullet = bullet.GetComponent<ExplodingBullet>();
            expBullet._explosionsLeft = _explosionsLeft - 1;
            expBullet._currentLifeTime = ExplodingStats.LifeTime / 2 / (ExplodingStats.ExplosionCount - expBullet._explosionsLeft + 1);
            bullet.SetActive(true);
        }
    }
}