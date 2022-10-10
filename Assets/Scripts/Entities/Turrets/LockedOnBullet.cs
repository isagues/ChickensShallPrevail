using Manager;
using UnityEngine;
using Utils;

namespace Entities.Turrets
{
    public class LockedOnBullet : Bullet
    {
        private GameObject          _target;
        private bool                _lockOn;
        private OnDestroyPublisher  _onDestroyPublisher;

        protected override void Start()
        {
            base.Start();
            _target = VectorUtils.FindClosestByTag(transform.position, "Enemy");
            if (_target is null)
            {
                _lockOn = false;
            }
            else
            {
                _lockOn = true;
                _onDestroyPublisher = OnDestroyPublisher.AttachPublisher(_target);
                _onDestroyPublisher.OnDestroyAction += LockOff;
            }
        }

        private void LockOff()
        {
            _lockOn = false;
        }

        protected new void Update()
        {
            if (_lockOn)
            {
                AutoMove.TravelToTarget(_target.transform.position);
            }
            else
            {
                AutoMove.Travel();
            }

            UpdateLifetime();
        }
        
        public void OnDestroy()
        {
            if (_lockOn)
            {
                _onDestroyPublisher.OnDestroyAction -= LockOff;
            }
        }
    }
}