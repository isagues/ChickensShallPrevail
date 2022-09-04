using System.Collections.Generic;
using UnityEngine;

// AL momento de creacion de la bala, si no existen los componentes los agrega
[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class Bullet: MonoBehaviour, IBullet
{
    public int Damage => _damage;
    [SerializeField] private int _damage = 10;
    
    public float LifeTime => _lifeTime;
    [SerializeField] private float _lifeTime = 5;
    
    public float Speed => _speed;
    [SerializeField] private float _speed = 5;

    public Rigidbody Rigidbody => _rigidBody;
    [SerializeField] private Rigidbody _rigidBody;
    public Collider Collider => _collider;
    [SerializeField] private Collider _collider;

    [SerializeField] private List<int> layerTarget;

    private void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();

        _collider.isTrigger = true;
        _rigidBody.useGravity = false;
        // _rigidBody.isKinematic = true;
        _rigidBody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
    }

    public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
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
        
        Travel();
    }
}