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
    }

    [System.Serializable]
    public struct CharacterStatValues
    {
        public float speed;
        public float rotationSpeed;
        public List<Deployeable> deployeables;
        public int collectableLayer;
    }
    
}