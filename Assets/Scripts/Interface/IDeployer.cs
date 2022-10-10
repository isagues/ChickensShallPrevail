using UnityEngine;

namespace Interface
{
    public interface IDeployer
    {
        GameObject DeployablePrefab { get; }
        
        void Deploy();
    }
}