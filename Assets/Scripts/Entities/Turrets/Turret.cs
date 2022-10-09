using Command;
using Manager;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Collider))]
    public class Turret : MonoBehaviour, ITurret 
    {
        [SerializeField] protected GameObject bulletPrefab;
        private IDamageable _damageable;
        private Collider _collider;

        public TurretType TurretType => turretType;
        [SerializeField] private TurretType turretType;

        public int Cost => cost;
        [SerializeField] private int cost;
        
        public float Period => period;
        [SerializeField] private float period;
        
        private float _nextShotTime = 0;
    
        #region ACCESORS
        public GameObject BulletPrefab => bulletPrefab;
        public IDamageable Damageable => _damageable;
        public Collider Collider => _collider;
    
        private CmdAttack _cmdAttack;
        #endregion
    
        public virtual void Attack()
        {
            var height = _collider.bounds.size.y / 4;
            var t = transform;
            var bullet = Instantiate(bulletPrefab, t.position + Vector3.up * height, t.rotation);
            bullet.name = bulletPrefab.name;
            bullet.transform.parent = transform;
        }

        protected virtual void Start()
        {
            _damageable = GetComponent<IDamageable>();
            _collider = GetComponent<Collider>();
            _cmdAttack = new CmdAttack(this);
        }

        protected virtual void Update()
        {
            if(Time.time > _nextShotTime) {
                _nextShotTime += period;
                EventQueueManager.instance.AddCommand(_cmdAttack);
            }
        }
    }
}
