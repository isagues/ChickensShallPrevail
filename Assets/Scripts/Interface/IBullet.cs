using System.Collections.Generic;
using UnityEngine;

namespace Interface
{
    public interface IBullet
    {
        int Damage { get; }
    
        float LifeTime { get; }
    
        List<int> LayerTarget { get; }
    
        Rigidbody Rigidbody { get; }
        Collider Collider { get; }
    
        void OnTriggerEnter(Collider otherCollider);
    }
}
