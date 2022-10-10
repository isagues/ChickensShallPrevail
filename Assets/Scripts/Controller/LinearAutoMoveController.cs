using System;
using Flyweight;
using UnityEngine;

namespace Controller
{
    public class LinearAutoMoveController: MonoBehaviour, IAutoMove
    {
        private ILinearAutoMoveStat _stat;
        public float Speed => _stat.Speed;
        public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * Speed));

        private void Start()
        {
            _stat = GetComponent<ILinearAutoMoveStat>();
        }

        public void TravelToTarget(Vector3 target)
        { 
            transform.LookAt(target);
            Travel();
        }
    }
    public interface ILinearAutoMoveStat
    {
        float Speed { get; }
    }
}
