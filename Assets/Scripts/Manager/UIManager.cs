using System;
using System.Collections.Generic;
using Entities;
using Entities.Turrets;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace Manager{

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Slider lifebar;
        [SerializeField] private Image  avatar;
        [SerializeField] private Image  egg;
        [SerializeField] private Text   eggAmout;
        [SerializeField] private Image  deployeableType;
        [SerializeField] private Text   deployeableName;
        [SerializeField] private Text   deployeableCost;
        
        private Dictionary<DeployeableType, Sprite> _deployeableSprites;
        
        private float _characterCurrentLife;
        
        private void LoadDeployeablesImages()
        {
            var resources = Resources.LoadAll("Sprites/Deployeables");
            foreach (var thisObject in resources)
            {
                var objectType = thisObject.GetType().Name;
                if (objectType != "Sprite") continue;
                if (Enum.TryParse(thisObject.name, true, out DeployeableType type))
                {
                    _deployeableSprites.Add(type, (Sprite)thisObject);
                }
            }
        }

        private void Awake()
        {
            _deployeableSprites = new Dictionary<DeployeableType, Sprite>();
            LoadDeployeablesImages();
            EventsManager.instance.OnDeployableChange += OnDeployableChange;
            EventsManager.instance.OnFarmLifeChange += UpdateLifeBar;
            EventsManager.instance.AddOnCollectableChangeHandler(CollectableType.Egg, OnCollectableChange);
        }
        
        private void OnCollectableChange(int currentCoins)
        {
            eggAmout.text = $"{currentCoins}";
        }

        private void OnDeployableChange(Deployeable deployeable)
        {
            if (!deployeable.DeployeableType(out var type)) return;
            
            deployeableType.sprite = _deployeableSprites[type];
            deployeableName.text = $"{type}";
            deployeableCost.text = $"{deployeable.Cost}";
        }
        
        private void UpdateLifeBar(float currentLife, float maxLife)
        {
            lifebar.value = currentLife / maxLife;
            _characterCurrentLife = currentLife;
        }
    }
}