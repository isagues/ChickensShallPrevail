using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Enemy: MonoBehaviour, IEnemy
{
    
    [SerializeField] private int _damage = 1;
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Collider _collider;
    
    [SerializeField] private IAutoMove _autoMoveController;
    
    [SerializeField] private List<int> _damageableLayerMask;
    
    #region ACCESORS
    public Rigidbody Rigidbody => _rigidBody;
    public Collider Collider => _collider;
    public int Damage => _damage;
    public IAutoMove AutoMove => _autoMoveController;
    #endregion

    private void OnCollisionStay(Collision collision)
    {
        if(_damageableLayerMask.Contains(collision.gameObject.layer))
        {
            var damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);
        }
    }
        
    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
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
