using System;
using Interface;
using UnityEngine;

namespace Entities
{
    public class Deployeable : MonoBehaviour
    {
        private IDeployeableStats _stats;

        private void Start()
        {
            enemyGameObject.GetComponent(typeof(IEnemy)) as IEnemy
            _stats = GetComponent(typeof(IDeployeableStats)) as IDeployeableStats;
        }

        public DeployeableType DeployeableType => _stats.DeployeableType;
        public int Cost => _stats.Cost;
        
    }
    public interface IDeployeableStats
    {
        DeployeableType DeployeableType { get; }
        int Cost { get; }
}
}