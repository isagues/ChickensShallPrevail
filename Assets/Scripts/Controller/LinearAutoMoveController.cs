using System;
using Flyweight;
using UnityEngine;

namespace Controller
{
    public class LinearAutoMoveController: MonoBehaviour, IAutoMove
    {
        private RaycastStat RaycastStats => raycastStats;
        [SerializeField] private RaycastStat raycastStats;
        
        private ILinearAutoMoveStat _stats;
        private ILinearAutoMoveStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<ILinearAutoMoveStat>();

        public float Speed => Stats.Speed;
        private float _currentBoostSpeed = 1;
        private bool _hasCollided = false;

        public void Travel()
        {
            if (!_hasCollided && RaycastStats != null)
            {
                var ray = new Ray(transform.position, RaycastStats.Direction);
                if (Physics.Raycast(ray, out var hit, RaycastStats.Range))
                {
                    if (RaycastStats.LayerTarget.Contains(hit.transform.gameObject.layer))
                    {
                        _hasCollided = true;
                        _currentBoostSpeed = RaycastStats.BoostedSpeed;
                    }
                } 
            }
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _currentBoostSpeed));
        }

        public void TravelToTarget(Vector3 target)
        {
            transform.LookAt(target);
            Travel();
        }
    }
    public interface ILinearAutoMoveStat
    {
        float Speed { get; }
    }
    
}
