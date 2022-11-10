using UnityEngine;

namespace Controller
{
    public class AimController : MonoBehaviour
    {
        [SerializeField] private Transform destination;

        private void Update()
        {
            var direction = destination.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);

            var targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}