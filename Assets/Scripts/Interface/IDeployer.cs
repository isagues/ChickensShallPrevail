using UnityEngine;

namespace Interface
{
    public interface IDeployer
    {
        GameObject BulletPrefab { get; }
        
        void Deploy();
    }
}