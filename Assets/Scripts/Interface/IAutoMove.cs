using System.Runtime.Serialization;
using UnityEngine;

public interface IAutoMove
{
    float Speed { get; }
    
    void Travel();
    
    void TravelToTarget(Vector3 target);
}