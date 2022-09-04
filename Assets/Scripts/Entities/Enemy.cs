using UnityEngine;

public class Enemy: MonoBehaviour, IEnemy
{
    public int Damage { get; }
    public Rigidbody Rigidbody { get; }
    public Collider Collider { get; }
    public void OnTriggerEnter(Collider otherCollider)
    {
        throw new System.NotImplementedException();
    }

    public float Speed { get; }
    public void Travel()
    {
        throw new System.NotImplementedException();
    }
}
