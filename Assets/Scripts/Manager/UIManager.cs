using System;
using System.Collections.Generic;
using Entities;
using Entities.Turrets;
using UnityEngine;
using UnityEngine.UI;

namespace Manager{

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Slider _lifebar;
        [SerializeField] private Image _avatar;
        [SerializeField] private Image _egg;
        [SerializeField] private Text _eggAmout;
        [SerializeField] private Image _turretType;
        [SerializeField] private Text _turretName;
        [SerializeField] private Text _turretCost;
        
        private Dictionary<TurretType, Sprite> turretSprites;
        
        private float _characterCurrentLife;
        
        void LoadTurretImages()
        {
            var resources = Resources.LoadAll("Sprites/Turrets");
            foreach (var thisObject in resources)
            {
                var objectType = thisObject.GetType().Name;
                if (objectType != "Sprite") continue;
                if (Enum.TryParse(thisObject.name, true, out TurretType type))
                {
                    turretSprites.Add(type, (Sprite)thisObject);
                }
            }
        }
        private void Start()
        {
            turretSprites = new Dictionary<TurretType, Sprite>();
            LoadTurretImages();
            EventsManager.instance.OnFarmLifeChange += UpdateLifeBar;
            EventsManager.instance.OnTurretChange += OnTurretChange;
            EventsManager.instance.AddOnCollectableChangeHandler(CollectableType.Egg, OnCollectableChange);
        }

        private void OnCollectableChange(int currentCoins)
        {
            _eggAmout.text = $"{currentCoins}";
        }

        private void OnTurretChange(Turret turret)
        {
            _turretType.sprite = turretSprites[turret.TurretType];
            _turretName.text = $"{turret.TurretType}";
            _turretCost.text = $"{turret.Cost}";
        }
        
        private void UpdateLifeBar(float currentLife, float maxLife)
        {
            _lifebar.value = currentLife / maxLife;
            _characterCurrentLife = currentLife;
        }
    }
}