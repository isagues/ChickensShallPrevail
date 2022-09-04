using UnityEngine;

public interface ITurret
{
    GameObject BulletPrefab { get; }
    
    void Attack();
    
}
