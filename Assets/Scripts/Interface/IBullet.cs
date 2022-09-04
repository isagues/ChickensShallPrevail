using UnityEngine;

public interface IBullet
{
    int Damage { get; }
    
    float LifeTime { get; }

    void OnTriggerEnter(Collider otherCollider);
}
