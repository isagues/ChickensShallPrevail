using System;
using UnityEngine;

namespace Entities
{
    public class Deployeable : MonoBehaviour
    {
        [SerializeField] private int cost;

        public int Cost => cost;

        public bool DeployeableType(out DeployeableType ret)
        {
            return Enum.TryParse(gameObject.name, true, out ret);
        }
    }

    public interface IDeployeableStats
    {
        DeployeableType DeployeableType { get; }
        int Cost { get; }
    }
}