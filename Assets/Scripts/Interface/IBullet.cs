using UnityEngine;

public interface IBullet
{
    int Damage { get; }
    
    float LifeTime { get; }
    
    Rigidbody Rigidbody { get; }
    Collider Collider { get; }
    
    void OnTriggerEnter(Collider otherCollider);
}
