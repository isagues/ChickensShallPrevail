using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "GranadeBulletStat", menuName = "Stats/GranadeBulletStat", order = 0)]
    public class GranadeBulletStat : BulletStat
    {
        [SerializeField] private GranadeBulletStatValues granadeStatValues;

        public float Radius => granadeStatValues.radius;
        
        public float Force => granadeStatValues.force;
        public float ExplosionDamage => granadeStatValues.explosionDamage;
    }

    [System.Serializable]
    public struct GranadeBulletStatValues
    {
        public float radius;
        public float force;
        public float explosionDamage;
    }
}