public interface IEnemy
{
    int Damage { get; }

    float LifeTime { get; }

    float Speed { get; }

    Rigidbody Rigidbody { get; }
    Collider Collider { get; }

    void Travel();

    void OnTriggerEnter(Collider otherCollider);
}
