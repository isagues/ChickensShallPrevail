using UnityEngine;



namespace Flyweight
{
    [CreateAssetMenu(fileName = "ActorStats", menuName = "Stats/Actor", order = 0)]
    public class ActorStats : ScriptableObject
    {
        [SerializeField] private StatValues _statValues;

        public int MaxLife => _statValues.MaxLife;
        public float MovementSpeed => _statValues.MovementSpeed;
        public float RotationSpeed => _statValues.RotationSpeed;
    }

    [System.Serializable]
    public struct StatValues
    {
        public int MaxLife;
        public float MovementSpeed;
        public float RotationSpeed;
    }
}