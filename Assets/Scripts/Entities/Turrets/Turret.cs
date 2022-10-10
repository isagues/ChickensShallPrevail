using Command;
using Controller;
using Flyweight;
using Manager;
using UnityEngine;

namespace Entities.Turrets
{
    [RequireComponent(typeof(Collider))]
    public class Turret : MonoBehaviour, ITurret
    {
        private IDamageable _damageable;
        private Collider _collider;
        private IListenable _listenable;

        private TurretStat _stats;
        
        private float _nextShotTime;
        
        public float Period => _stats.Period;
        public GameObject BulletPrefab => _stats.BulletPrefab;
        public IDamageable Damageable => _damageable;
        public Collider Collider => _collider;
        public IListenable Listenable => _listenable;
        
        private CmdAttack _cmdAttack;

        private void Awake()
        {
            _stats = GetComponent<StatSupplier>().GetStat<TurretStat>();
            
            _damageable = GetComponent<IDamageable>();
            _collider = GetComponent<Collider>();
            _listenable = GetComponent<IListenable>();
            
            _cmdAttack = new CmdAttack(this);
            _nextShotTime = Time.time;
        }
        
        public void Attack()
        {
            var height = _collider.bounds.size.y / 4;
            var t = transform;
            var bullet = Instantiate(BulletPrefab, t.position + Vector3.up * height, t.rotation);
            bullet.name = BulletPrefab.name;
            bullet.transform.parent = transform;
            _listenable.Play();
        }

        protected void Update()
        {
            if(Time.time > _nextShotTime) {
                _nextShotTime += Period;
                EventQueueManager.instance.AddCommand(_cmdAttack);
            }
        }
    }
}
