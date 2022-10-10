using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface IBullet
    {
        int Damage { get; }
    
        float LifeTime { get; }
    
        List<int> LayerTarget { get; }
        
        void OnTriggerEnter(Collider otherCollider);
    }
}
