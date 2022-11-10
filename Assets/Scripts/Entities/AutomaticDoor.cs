using System;
using System.Collections.Generic;
using UnityEngine;

namespace Entities
{
    public class AutomaticDoor : MonoBehaviour
    {

        Animator m_Animator;
        [SerializeField] private List<int> LayerTarget;

        void Start()
        {
            //Get the Animator attached to the GameObject you are intending to animate.
            m_Animator = gameObject.GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!LayerTarget.Contains(other.gameObject.layer)) return;

            
            m_Animator.ResetTrigger("Close");

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            m_Animator.SetTrigger("Open");
        }

        private void OnTriggerExit(Collider other)
        {
            if (!LayerTarget.Contains(other.gameObject.layer)) return;

            
            m_Animator.ResetTrigger("Open");

            //Send the message to the Animator to activate the trigger parameter named "Jump"
            m_Animator.SetTrigger("Close");
        }
    }
}