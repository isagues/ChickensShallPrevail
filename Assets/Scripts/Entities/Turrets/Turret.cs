
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Turret : MonoBehaviour, ITurret 
{
    
    [SerializeField] protected GameObject _bulletPrefab;
    private IDamageable _damageable;
    
    private float nextShotTime = 0;
    [SerializeField] private float period;
    
    #region ACCESORS
    public GameObject BulletPrefab => _bulletPrefab;
    public IDamageable Damageable => _damageable;
    #endregion
    
    public virtual void Attack()
    {
        var bullet = Instantiate(_bulletPrefab, transform.position + Vector3.forward * 5, transform.rotation);
        bullet.name = "Bala Turret";
    }

    private void Start()
    {
        _damageable = GetComponent<IDamageable>();
    }

    private void Update()
    {
        if(Time.time > nextShotTime ) {
            nextShotTime += period;
            Attack();
        }
    }
}
