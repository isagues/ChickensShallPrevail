using System.Runtime.Serialization;
using UnityEngine;

public interface IAutoMove
{
    float Speed { get; }
    
    void Travel();

    bool isBoosted();
     
    void TravelToTarget(Vector3 target);
}