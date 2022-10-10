using System;
using Manager;
using UnityEngine;

namespace Entities
{
    public class Farm : MonoBehaviour
    {
        private const double TOLERANCE = 0.0001;

        private IListenable _listenable;
        
        private IListenable Listenable => _listenable;

        private void Awake()
        {
            EventsManager.instance.OnFarmLifeChange += FarmLifeChange;
            _listenable = GetComponent<IListenable>();
        }

        private void FarmLifeChange(float currentLife, float maxLife)
        {
            if (Math.Abs(currentLife - maxLife) < TOLERANCE) return;
            
            if (currentLife < TOLERANCE) EventsManager.instance.EventGameOver(false);
            else _listenable.Play();
            
        }
    }
}