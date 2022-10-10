using System;
using Flyweight;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controller
{
    public class RandomWalkAutoMoveController: MonoBehaviour, IAutoMove
    {
        private IRandomAutoMoveStat _stats;
        public float Speed => _stats.Speed;

        private float _rotation = 0f;
        private void Start()
        {
            _stats = GetComponent<IRandomAutoMoveStat>();
        }

        public void Travel()
        {
            _rotation += Random.Range(-0.05f, 0.05f);
            _rotation = Mathf.Clamp(_rotation, -1, 1);
            transform.Rotate(_rotation * Vector3.up);
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
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