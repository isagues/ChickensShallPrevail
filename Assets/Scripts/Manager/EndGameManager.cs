using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField] private string victoryText;
        [SerializeField] private string defeatText;
        [SerializeField] private Color victoryColor;
        [SerializeField] private Color defeatColor;
        [SerializeField] private Text  _text;

        private void Update()
        {
            _text.text = GlobalData.instance.IsVictory ? victoryText : defeatText;
            _text.color = GlobalData.instance.IsVictory ? victoryColor : defeatColor;
        }
    }
}