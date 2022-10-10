using System.Collections.Generic;
using Controller;
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
        public List<int> LayerTarget => statValues.layerTarget;
    }

    [System.Serializable]
    public struct BulletStatValues
    {
        public float speed;
        public int damage;
        public float lifeTime;
        public List<int> layerTarget;
    }
    
}