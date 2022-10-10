using Controller;
using Entities;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "TurretStat", menuName = "Stats/TurretStat", order = 0)]
    public class TurretStat : ScriptableObject, ILifeControllerStat, IDeployeableStats
    {
        [SerializeField] private TurretStatValues statValues;
        
        public float MaxLife => statValues.maxLife;
        public int Cost => statValues.cost;
        public float Period => statValues.period;
        public GameObject BulletPrefab => statValues.bulletPrefab;
    }

    [System.Serializable]
    public struct TurretStatValues
    {
        public float maxLife;
        public int cost;
        public float period;
        public GameObject bulletPrefab;
    }
}