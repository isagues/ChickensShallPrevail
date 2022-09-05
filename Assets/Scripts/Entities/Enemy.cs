using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Enemy: MonoBehaviour, IEnemy
{
    
    [SerializeField] private int _damage = 1;
    [SerializeField] private List<int> _damageableLayerMask;
    
    private Rigidbody _rigidBody;
    private Collider _collider;
    private IDamageable _damageable;
    private IAutoMove _autoMoveController;
    
    
    #region ACCESORS
    public Rigidbody Rigidbody => _rigidBody;
    public Collider Collider => _collider;
    public IDamageable Damageable => _damageable;
    public int Damage => _damage;
    public IAutoMove AutoMove => _autoMoveController;
    #endregion

    private void OnCollisionStay(Collision collision)
    {
        if (!_damageableLayerMask.Contains(collision.gameObject.layer)) return;
        
        var damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(Damage);
    }
        
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _damageable = GetComponent<IDamageable>();
        _autoMoveController = GetComponent<IAutoMove>();

        _rigidBody.useGravity = false;
        // _rigidBody.isKinematic = true;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }
    
    private void Update()
    {
        _autoMoveController.Travel();
    }
}
