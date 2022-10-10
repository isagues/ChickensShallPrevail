using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "ExplodingBulletStat", menuName = "Stats/ExplodingBulletStat", order = 0)]
    public class ExplodingBulletStat : BulletStat
    {
        [SerializeField] private ExplodingBulletStatValues explotionStatValues;
        public int ExplosionCount => explotionStatValues.explosionCount;
    }

    [System.Serializable]
    public struct ExplodingBulletStatValues
    {
        public int explosionCount;
    }
    
}