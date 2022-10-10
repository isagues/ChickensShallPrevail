using Flyweight;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Controller
{
    public class MovementController: MonoBehaviour, IMovable
    {
        private IMovementStats _stats;
        private IMovementStats Stats => _stats ??= GetComponent<StatSupplier>().GetStat<IMovementStats>();

        public float Speed => Stats.Speed;
        public float RotationSpeed => Stats.RotationSpeed;

        public void Travel(Vector3 direction) => transform.Translate(direction * (Time.deltaTime * Speed));

        public void Rotate(Vector3 direction) => transform.Rotate(direction * (Time.deltaTime * RotationSpeed));
    }
    
    public interface IMovementStats
    {
        float Speed { get; }
        float RotationSpeed { get; }
    }
}
