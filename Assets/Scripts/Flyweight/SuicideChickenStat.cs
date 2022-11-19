using System.Collections.Generic;
using Controller;
using Entities;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "SuicideChickenStat", menuName = "Stats/SuicideChickenStat", order = 0)]
    public class SuicideChickenStat : ScriptableObject, ILinearAutoMoveStat
    {
        [SerializeField] private SuicideChickenStatValues statValues;
        public float Speed => statValues.speed;
        public float Damage => statValues.damage;
        public float Force => statValues.force;
        public float Radius => statValues.radius;
        
        public GameObject ExplosionPrefab => statValues.explosionPrefab;
        public List<int> LayerTarget => statValues.layerTarget;
    }

    [System.Serializable]
    public struct SuicideChickenStatValues
    {
        public float speed;
        public float damage;
        public float force;
        public float radius;
        public GameObject explosionPrefab;
        public List<int> layerTarget;
    }
    
}