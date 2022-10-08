using Flyweight;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Controller
{
    public class MovementController: MonoBehaviour, IMovable
    {

        [SerializeField] private ActorStats _actorStats;
        public float Speed => _actorStats.MovementSpeed;

        public float RotationSpeed => _actorStats.RotationSpeed;

        public void Travel(Vector3 direction) => transform.Translate(direction * (Time.deltaTime * Speed));

        public void Rotate(Vector3 direction) => transform.Rotate(direction * (Time.deltaTime * RotationSpeed));
    }
}
