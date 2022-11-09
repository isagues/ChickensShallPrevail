using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "PropagatingBulletStat", menuName = "Stats/PropagatingBulletStat", order = 0)]
    public class PropagatingBulletStat : BulletStat
    {
        [SerializeField] private PropagatingBulletStatValues explosionStatValues;
        public int ExplosionCount => explosionStatValues.explosionCount;
    }

    [System.Serializable]
    public struct PropagatingBulletStatValues
    {
        public int explosionCount;
    }
    
}