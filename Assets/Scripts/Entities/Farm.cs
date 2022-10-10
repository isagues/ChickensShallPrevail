using System;
using Manager;
using UnityEngine;

namespace Entities
{
    public class Farm : MonoBehaviour
    {
        private const double Tolerance = 0.0001;

        private IListenable Listenable { get; set; }

        private void Awake()
        {
            EventsManager.instance.OnFarmLifeChange += FarmLifeChange;
            Listenable = GetComponent<IListenable>();
        }

        private void FarmLifeChange(float currentLife, float maxLife)
        {
            if (Math.Abs(currentLife - maxLife) < Tolerance) return;
            
            if (currentLife < Tolerance) EventsManager.instance.EventGameOver(false);
            else Listenable.Play();
        }
    }
}