
using System;
using UnityEngine;

public class Turret : MonoBehaviour, ITurret 
{
    public GameObject BulletPrefab => _bulletPrefab;
    [SerializeField] protected GameObject _bulletPrefab;
    
    private float nextShotTime = 0;
    [SerializeField] private float period;

    private void Start()
    {
        Debug.Log("Started Turret");
    }
    
    public virtual void Attack()
    {
        // Se crea en la posicion y direccion del character.
        var bullet = Instantiate(_bulletPrefab, transform.position + Vector3.forward * 5, transform.rotation);
        bullet.name = "Bala Turret";
    }

    private void Update()
    {
        if(Time.time > nextShotTime ) {
            nextShotTime += period;
            Attack();
        }
    }
}
