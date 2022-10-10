using Controller;
using UnityEngine;

namespace Flyweight
{
    [CreateAssetMenu(fileName = "FarmStat", menuName = "Stats/FarmStat", order = 0)]
    public class FarmStat : ScriptableObject, ILifeControllerStat
    {
        [SerializeField] private FarmStatValues statValues;
        
        public float MaxLife => statValues.maxLife;
    }

    [System.Serializable]
    public struct FarmStatValues
    {
        public float maxLife;
    }
}