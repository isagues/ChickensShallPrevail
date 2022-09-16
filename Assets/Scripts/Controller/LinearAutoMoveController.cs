using System.Runtime.Serialization;
using Flyweight;
using UnityEngine;

public class LinearAutoMoveController: MonoBehaviour, IAutoMove
{
    [SerializeField] private ActorStats _actorStats;
    public float Speed => _actorStats.MovementSpeed;

    public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * Speed));
}
