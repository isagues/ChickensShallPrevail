using Entities;
using Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Manager{

    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _egg;
        [SerializeField] private Slider _lifebar;
        [SerializeField] private Image _avatar;
        [SerializeField] private Text _eggAmout;
        
        private float _characterCurrentLife;

        private void Start()
        {
            EventsManager.instance.OnCharacterLifeChange += UpdateLifeBar;
            EventsManager.instance.AddOnCollectableChangeHandler(CollectableType.Egg, OnCollectableChange);
        }

        private void OnCollectableChange(int currentCoins)
        {
            _eggAmout.text = $"{currentCoins}";
        }
        
        private void UpdateLifeBar(float currentLife, float maxLife)
        {
            _lifebar.value = currentLife / maxLife;
            _characterCurrentLife = currentLife;
        }
    }
}