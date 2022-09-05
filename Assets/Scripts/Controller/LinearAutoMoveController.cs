using System.Runtime.Serialization;
using UnityEngine;

public class LinearAutoMoveController: MonoBehaviour, IAutoMove
{
    public float Speed => _speed;
    [SerializeField] private float _speed = 5;

    public void Travel() => transform.Translate(Vector3.forward * (Time.deltaTime * _speed));
}
