public interface IAutoMove
{
    float Speed { get; }
    
    Rigidbody Rigidbody { get; }
    Collider Collider { get; }

    void Travel();
}