using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "CatapultStat", menuName = "Stats/CatapultStat", order = 0)]
    public class CatapultStat : TurretStat
    {
        [SerializeField] private CatapultStats catapultStatValues;
        
        public float Force => catapultStatValues.force;
    }
    
    [System.Serializable]
    public struct CatapultStats
    {
        public float force;
    }
}