using UnityEngine;

public interface ITurret
{
    GameObject BulletPrefab { get; }
    
    IDamageable Damageable { get; }
    
    void Attack();
    
}
