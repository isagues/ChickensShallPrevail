using Flyweight;
using UnityEngine;

namespace Controller
{
    public class LinearAutoMoveController: MonoBehaviour, IAutoMove
    {
        [SerializeField] private ActorStats _actorStats;
        public float Speed => _actorStats.MovementSpeed;
        
        public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
        
        public void TravelToTarget(Vector3 target)
        { 
            transform.LookAt(target);
            Travel();
        }
    }
}
