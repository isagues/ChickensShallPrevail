using System.Collections.Generic;
using Controller;
using Entities;
using UnityEngine;



namespace Flyweight
{
    [CreateAssetMenu(fileName = "BulletStat", menuName = "Stats/BulletStat", order = 0)]
    public class BulletStat : ScriptableObject, ILinearAutoMoveStat
    {
        [SerializeField] private BulletStatValues statValues;
        public float Speed => statValues.speed;
        
        public int Damage => statValues.damage;
        
        public float LifeTime => statValues.lifeTime;
    }

    [System.Serializable]
    public struct BulletStatValues
    {
        public float speed;
        public int damage;
        public float lifeTime;
    }
    
}