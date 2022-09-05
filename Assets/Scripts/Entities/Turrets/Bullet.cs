using System.Collections.Generic;
using UnityEngine;

// AL momento de creacion de la bala, si no existen los componentes los agrega
[RequireComponent(typeof(Rigidbody), typeof(Collider), typeof(IAutoMove))]
public class Bullet: MonoBehaviour, IBullet
{
    public int Damage => _damage;
    [SerializeField] private int _damage = 10;
    
    public float LifeTime => _lifeTime;
    [SerializeField] private float _lifeTime = 5;

    public Rigidbody Rigidbody => _rigidBody;
    [SerializeField] private Rigidbody _rigidBody;
    public Collider Collider => _collider;
    [SerializeField] private Collider _collider;
    
    public IAutoMove AutoMove => _autoMoveController;
    [SerializeField] private IAutoMove _autoMoveController;

    [SerializeField] private List<int> layerTarget;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
        _autoMoveController = GetComponent<IAutoMove>();

        _collider.isTrigger = true;
        _rigidBody.useGravity = false;
        _rigidBody.isKinematic = true; //Inafectable
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        if (!layerTarget.Contains(otherCollider.gameObject.layer)) return;
        Debug.LogError("Trigger");
        
        IDamageable damageable = otherCollider.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damage);
        
        Destroy(this.gameObject);
    }

    private void Update()
    {
        _lifeTime -= Time.deltaTime;
        if(_lifeTime <= 0) Destroy(this.gameObject);
        
        _autoMoveController.Travel();
    }
}