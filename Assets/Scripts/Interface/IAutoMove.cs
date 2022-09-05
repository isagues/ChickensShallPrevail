using System.Runtime.Serialization;

public interface IAutoMove
{
    float Speed { get; }
    
    void Travel();
}