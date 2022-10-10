using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Manager
{
    public class EventQueueManager : MonoBehaviour
    {
        public static EventQueueManager instance;

        private Queue<ICommand> _events;
        
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(this);
                return;
            }
            instance = this;
            
            _events = new Queue<ICommand>();
        }

        private void Update()
        {
            ProcessQueue(_events);
        }

        public void AddCommand(ICommand command) => _events.Enqueue(command);
        
        private static void ProcessQueue(Queue<ICommand> events) {
            while(events.Count > 0)
            {
                events.Dequeue().Execute();
            }
        }
    }
}