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
        [SerializeField] private Slider _lifebar;
        [SerializeField] private Image _avatar;
        [SerializeField] private Image _egg;
        [SerializeField] private Text _eggAmout;
        [SerializeField] private Image _deployeableType;
        [SerializeField] private Text _deployeableName;
        [SerializeField] private Text _deployeableCost;
        
        private Dictionary<DeployeableType, Sprite> deployeableSprites;
        
        private float _characterCurrentLife;
        
        void LoadDeployeablesImages()
        {
            var resources = Resources.LoadAll("Sprites/Deployeables");
            foreach (var thisObject in resources)
            {
                var objectType = thisObject.GetType().Name;
                if (objectType != "Sprite") continue;
                if (Enum.TryParse(thisObject.name, true, out DeployeableType type))
                {
                    deployeableSprites.Add(type, (Sprite)thisObject);
                }
            }
        }

        private void Awake()
        {
            deployeableSprites = new Dictionary<DeployeableType, Sprite>();
            LoadDeployeablesImages();
            EventsManager.instance.OnDeployableChange += OnDeployableChange;
            EventsManager.instance.OnFarmLifeChange += UpdateLifeBar;
            EventsManager.instance.AddOnCollectableChangeHandler(CollectableType.Egg, OnCollectableChange);
        }
        
        private void OnCollectableChange(int currentCoins)
        {
            _eggAmout.text = $"{currentCoins}";
        }

        private void OnDeployableChange(Deployeable deployeable)
        {
            _deployeableType.sprite = deployeableSprites[deployeable.DeployeableType];
            _deployeableName.text = $"{deployeable.DeployeableType}";
            _deployeableCost.text = $"{deployeable.Cost}";
        }
        
        private void UpdateLifeBar(float currentLife, float maxLife)
        {
            _lifebar.value = currentLife / maxLife;
            _characterCurrentLife = currentLife;
        }
    }
}