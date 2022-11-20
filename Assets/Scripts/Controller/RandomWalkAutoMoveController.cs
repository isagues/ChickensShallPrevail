using System;
using Flyweight;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller
{
    public class RandomWalkAutoMoveController: MonoBehaviour, IAutoMove
    {
        private IRandomAutoMoveStat _stats;
        private IRandomAutoMoveStat Stats => _stats ??= GetComponent<StatSupplier>().GetStat<IRandomAutoMoveStat>();
        
        public float Speed => Stats.Speed;

        private float _rotation = 0f;

        public void Travel()
        {
            _rotation += Random.Range(-0.05f, 0.05f);
            _rotation = Mathf.Clamp(_rotation, -1, 1);
            transform.Rotate(_rotation * Vector3.up);
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        }

        public bool isBoosted()
        {
            return false;
        }

        public void TravelToTarget(Vector3 target)
        {
            throw new NotSupportedException();
        }
    }
    public interface IRandomAutoMoveStat
    {
        float Speed { get; }
    }
}