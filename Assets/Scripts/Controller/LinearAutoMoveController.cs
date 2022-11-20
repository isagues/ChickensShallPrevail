using System;
using System.Collections.Generic;
using Flyweight;
using UnityEngine;

namespace Controller
{
    public class LinearAutoMoveController: MonoBehaviour, IAutoMove
    {
        private ILinearAutoMoveStat _stats;
        private ILinearAutoMoveStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<ILinearAutoMoveStat>();

        public float Speed => Stats.Speed;

        public virtual void Travel()
        {
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        }

        public virtual bool isBoosted()
        {
            return false;
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
