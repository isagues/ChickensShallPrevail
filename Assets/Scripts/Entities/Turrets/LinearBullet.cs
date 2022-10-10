using Flyweight;

namespace Entities.Turrets
{
    public class LinearBullet: Bullet
    {
        private BulletStat _stats;
        protected override BulletStat Stats() => _stats ??= GetComponent<StatSupplier>().GetStat<BulletStat>();
    }
}