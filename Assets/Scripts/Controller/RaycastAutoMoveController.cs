using System.Collections.Generic;
using Flyweight;
using UnityEngine;

namespace Controller
{
    public class RaycastAutoMoveController : LinearAutoMoveController
    {
        private IRaycastStat _raycastStats;
        private IRaycastStat RaycastStats => _raycastStats ??= GetComponent<StatSupplier>().GetStat<IRaycastStat>();
        
        private float _currentBoostSpeed = 1;
        private bool _hasCollided = false;

        public override void Travel()
        {
            if (!_hasCollided )
            {
                var ray = new Ray(transform.position, RaycastStats.Direction);
                if (Physics.Raycast(ray, out var hit, RaycastStats.Range))
                {
                    if (RaycastStats.RaycastTargets.Contains(hit.transform.gameObject.layer))
                    {
                        _hasCollided = true;
                        _currentBoostSpeed = RaycastStats.BoostedSpeed;
                    }
                } 
            }
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed * _currentBoostSpeed));
        }

        public override bool isBoosted()
        {
            return _hasCollided;
        }
    }
    public interface IRaycastStat
    {
        float Range { get; }
        float BoostedSpeed { get; }
        List<int>  RaycastTargets { get; }
        Vector3 Direction { get; }

    }
}