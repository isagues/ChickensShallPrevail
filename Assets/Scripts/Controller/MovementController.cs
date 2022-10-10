using System;
using Flyweight;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Controller
{
    public class MovementController: MonoBehaviour, IMovable
    {
        private IMovementStats _stats;
        public float Speed => _stats.Speed;

        public float RotationSpeed => _stats.RotationSpeed;

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<IMovementStats>();
        }

        public void Travel(Vector3 direction) => transform.Translate(direction * (Time.deltaTime * Speed));

        public void Rotate(Vector3 direction) => transform.Rotate(direction * (Time.deltaTime * RotationSpeed));
    }
    
    public interface IMovementStats
    {
        float Speed { get; }
        float RotationSpeed { get; }
    }
}
