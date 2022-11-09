using System;
using UnityEngine;

namespace Controller
{
    public class AimController : MonoBehaviour
    {
        [SerializeField] private Transform _destination;

        private void Update()
        {
            Vector3 direction = _destination.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
    }
}