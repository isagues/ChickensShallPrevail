using System;
using Flyweight;
using UnityEngine;

namespace Entities
{
    public class Deployeable : MonoBehaviour
    {
        private IDeployeableStats _stats;
        private IDeployeableStats Stats => _stats ??= GetComponent<StatSupplier>().GetStat<IDeployeableStats>();

        public int Cost => Stats.Cost;

        public bool DeployeableType(out DeployeableType ret)
        {
            return Enum.TryParse(gameObject.name, true, out ret);
        }
    }

    public interface IDeployeableStats
    {
        int Cost { get; }
    }
}