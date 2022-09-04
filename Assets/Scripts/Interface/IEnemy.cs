using UnityEngine;

public interface IEnemy
{
    int Damage { get; }
    
    Rigidbody Rigidbody { get; }
    
    Collider Collider { get; }
    
    void OnTriggerEnter(Collider otherCollider);
}
