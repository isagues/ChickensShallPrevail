using Entities;
using UnityEngine;

namespace Interface
{
    public interface IDeployeable
    {
        int Cost { get; }
        
        DeployeableType DeployeableType { get; }
        void DeployInstance(Vector3 position, Quaternion rotation);
    }
}