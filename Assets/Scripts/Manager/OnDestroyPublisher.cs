using System;
using UnityEngine;

namespace Manager
{
    public class OnDestroyPublisher : MonoBehaviour
    {
        public event Action OnDestroyAction;

        public static OnDestroyPublisher AttachPublisher(GameObject gameObject)
        {
            return gameObject.TryGetComponent(out OnDestroyPublisher publisher)
                ? publisher
                : gameObject.AddComponent<OnDestroyPublisher>()
                ;
        }

        private void OnDestroy()
        {
            OnDestroyAction?.Invoke();
        }
    }
}