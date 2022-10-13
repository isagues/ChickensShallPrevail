using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "ExplodingBulletStat", menuName = "Stats/ExplodingBulletStat", order = 0)]
    public class ExplodingBulletStat : BulletStat
    {
        [SerializeField] private ExplodingBulletStatValues explosionStatValues;
        public int ExplosionCount => explosionStatValues.explosionCount;
    }

    [System.Serializable]
    public struct ExplodingBulletStatValues
    {
        public int explosionCount;
    }
    
}