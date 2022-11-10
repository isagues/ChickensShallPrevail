using Flyweight;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(IAutoMove))]
    public class LinearBullet: Bullet
    {
        private BulletStat _stats;
        protected override BulletStat Stats() => _stats ??= GetComponent<StatSupplier>().GetStat<BulletStat>();
        protected override void Travel()
        {
            AutoMove.Travel();
        }
    }
}