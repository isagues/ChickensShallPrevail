using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class MovementController: MonoBehaviour, IMovable
{
    public float Speed => _speed;
    [SerializeField] private float _speed = 5;
    
    public float RotationSpeed=> _rotationSpeed;
    [SerializeField] private float _rotationSpeed = 10;

    public void Travel(Vector3 direction) => transform.Translate(direction * (Time.deltaTime * _speed));

    public void Rotate(Vector3 direction) => transform.Rotate(direction * (Time.deltaTime * _rotationSpeed));
}
