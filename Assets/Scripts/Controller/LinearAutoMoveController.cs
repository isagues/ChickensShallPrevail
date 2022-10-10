using System;
using Flyweight;
using UnityEngine;

namespace Controller
{
    public class LinearAutoMoveController: MonoBehaviour, IAutoMove
    {
        private ILinearAutoMoveStat _stats;
        public float Speed => _stats.Speed;
        public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * Speed));

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<ILinearAutoMoveStat>();
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
