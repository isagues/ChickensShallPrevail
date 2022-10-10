using System.Collections.Generic;
using Controller;
using Entities;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "ChickenStat", menuName = "Stats/ChickenStat", order = 0)]
    public class ChickenStat : ScriptableObject, ILifeControllerStat, IRandomAutoMoveStat, IDeployeableStats
    {
        [SerializeField] private ChickenStatValues statValues;
        
        public float MaxLife => statValues.maxLife;
        public float Speed => statValues.speed;
        public int Cost => statValues.cost;
        public int Period => statValues.period;
        public GameObject EggPrefab => statValues.eggPrefab;
        public List<int> LayerTarget => statValues.layerTarget;
    }

    [System.Serializable]
    public struct ChickenStatValues
    {
        public float maxLife;
        public float speed;
        public int cost;
        public int period;
        public GameObject eggPrefab;
        public List<int> layerTarget;
    }
    
}