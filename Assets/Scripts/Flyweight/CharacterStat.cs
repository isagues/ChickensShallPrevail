using System.Collections.Generic;
using Controller;
using Entities;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "CharacterStat", menuName = "Stats/CharacterStat", order = 0)]
    public class CharacterStat : ScriptableObject, IMovementStats, ICollectorStats
    {
        [SerializeField] private CharacterStatValues statValues;
        
        public float Speed => statValues.speed;
        public float RotationSpeed => statValues.rotationSpeed;
        public  List<Deployeable> Deployeables => statValues.deployeables;
        public int CollectableLayer => statValues.collectableLayer;
        public float Radius => statValues.radius;
        public float Force => statValues.force;
        public float AttackCooldown => statValues.attackCooldown;
        public List<int> LayerTarget => statValues.layerTarget;
    }

    [System.Serializable]
    public struct CharacterStatValues
    {
        public float speed;
        public float rotationSpeed;
        public float radius;
        public float force;
        public float attackCooldown;
        public List<Deployeable> deployeables;
        public int collectableLayer;
        public List<int> layerTarget;
    }
    
}