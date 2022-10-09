using Interface;
using UnityEngine;

namespace Entities
{
    public class Deployeable : MonoBehaviour
    {
        [SerializeField] private DeployeableType _deployeableType;
        [SerializeField] private int cost;
        public DeployeableType DeployeableType => _deployeableType;
        public int Cost => cost;
        
    }
}