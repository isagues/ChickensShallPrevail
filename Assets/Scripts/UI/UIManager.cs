using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Image _egg;
        [SerializeField] private Image _lifebar;
        [SerializeField] private Image _avatar;

        [SerializeField] private Text _eggAmout;
        
        private void Start()
        {
            //Aca iria mi Event manager
        }

        private void OnCoinChange(int currentCoins)
        {
            _eggAmout.text = $"{currentCoins}";
        }
    }
}