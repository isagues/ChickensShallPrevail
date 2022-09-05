
using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Turret : MonoBehaviour, ITurret 
{
    
    [SerializeField] protected GameObject _bulletPrefab;
    private IDamageable _damageable;
    private Collider _collider;
    
    private float nextShotTime = 0;
    [SerializeField] private float period;
    
    #region ACCESORS
    public GameObject BulletPrefab => _bulletPrefab;
    public IDamageable Damageable => _damageable;
    public Collider Collider => _collider;
    #endregion
    
    public virtual void Attack()
    {
        float height = _collider.bounds.size.y / 4;
        var bullet = Instantiate(_bulletPrefab, transform.position + Vector3.up * height, transform.rotation);
        bullet.name = "Bala Turret";
    }

    private void Start()
    {
        _damageable = GetComponent<IDamageable>();
        _collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if(Time.time > nextShotTime ) {
            nextShotTime += period;
            Attack();
        }
    }
}
