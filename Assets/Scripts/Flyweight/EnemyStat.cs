using System.Collections.Generic;
using Controller;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "EnemyStat", menuName = "Stats/EnemyStat", order = 0)]
    public class EnemyStat : ScriptableObject, ILifeControllerStat, ILinearAutoMoveStat, IRaycastStat
    {
        [SerializeField] private EnemyStatValues statValues;
        
        public float MaxLife => statValues.maxLife;
        public float Speed => statValues.speed;
        public int Damage => statValues.damage;
        public float AttackTime => statValues.attackTime;
        public List<int> DamageableLayerMask => statValues.damageableLayerMask;
        public int TargetLayer => statValues.targetLayer;
        public float Range => statValues.raycastRange;
        public float BoostedSpeed => statValues.boostedSpeed;
        public List<int> RaycastTargets => statValues.raycastTargets;
        public Vector3 Direction => statValues.direction;
    }

    [System.Serializable]
    public struct EnemyStatValues
    {
        public float maxLife;
        public float speed;
        public float raycastRange;
        public float boostedSpeed;
        public int damage;
        public float attackTime;
        public int targetLayer;
        public List<int> damageableLayerMask;
        public List<int> raycastTargets;
        public Vector3 direction;
    }
}