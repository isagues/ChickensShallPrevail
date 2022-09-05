using UnityEngine;

public interface ITurret
{
    GameObject BulletPrefab { get; }
    
    IDamageable Damageable { get; }
    Collider Collider { get; }
    
    void Attack();
    
}
