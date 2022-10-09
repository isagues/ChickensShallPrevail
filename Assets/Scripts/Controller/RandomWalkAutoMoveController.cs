using Flyweight;
using UnityEngine;

namespace Controller
{
    public class RandomWalkAutoMoveController: MonoBehaviour, IAutoMove
    {
        [SerializeField] private ActorStats _actorStats;
        public float Speed => _actorStats.MovementSpeed;

        private float rotation = 0f;
        
        public void Travel()
        {
            rotation += Random.Range(-0.05f, 0.05f);
            rotation = Mathf.Clamp(rotation, -1, 1);
            transform.Rotate(rotation * Vector3.up);
            transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        }

        public void TravelToTarget(Vector3 target)
        {
            throw new System.Exception("PLOP");
        }
    }
}