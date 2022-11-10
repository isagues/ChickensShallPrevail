using System.Collections.Generic;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "RaycastStat", menuName = "Stats/RaycastStat", order = 0)]
    public class RaycastStat : ScriptableObject
    {
        [SerializeField] private RaycastStatValues statValues;
        public float Range => statValues.range;
        public float BoostedSpeed => statValues.boostedSpeed;
        public List<int> LayerTarget => statValues.layerTarget;
        public Vector3 Direction => statValues.direction;
        
    }

    [System.Serializable]
    public struct RaycastStatValues
    {
        public float range;
        public float boostedSpeed;
        public List<int> layerTarget;
        public Vector3 direction;
    }
}