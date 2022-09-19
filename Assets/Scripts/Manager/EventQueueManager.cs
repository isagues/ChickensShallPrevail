using System;
using System.Collections.Generic;
using Interface;
using UnityEngine;

namespace Manager
{
    public class EventQueueManager : MonoBehaviour
    {
        public static EventQueueManager instance;
        
        public Queue<ICommand> Events => _events;
        private Queue<ICommand> _events = new Queue<ICommand>();
        private void Awake()
        {
            if(instance != null) Destroy(this);
            instance = this;
        }

        private void Update()
        {
            ProcessQueue(_events);
        }

        public void AddCommand(ICommand command) => _events.Enqueue(command);
        
        public void ProcessQueue(Queue<ICommand> events) {
            while(_events.Count > 0)
            {
                _events.Dequeue().Execute();
            }

            _events.Clear();
        }
    }
}