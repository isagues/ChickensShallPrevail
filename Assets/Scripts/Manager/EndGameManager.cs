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

        private void Start()
        {
            var endText = GetComponent<Text>();
            endText.text = GlobalData.instance.IsVictory ? victoryText : defeatText;
            endText.color = GlobalData.instance.IsVictory ? victoryColor : defeatColor;
        }
    }
}