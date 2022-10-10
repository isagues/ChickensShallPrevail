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
        public DeployeableType DeployeableType => statValues.deployeableType;
        public int Cost => statValues.cost;

        public int Period => statValues.period;
    }

    [System.Serializable]
    public struct ChickenStatValues
    {
        public float maxLife;
        public float speed;
        public DeployeableType deployeableType;
        public int cost;
        public int period;
    }
    
}