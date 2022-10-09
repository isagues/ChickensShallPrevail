using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField] private String _victoryText;
        [SerializeField] private String _defeatText;
        [SerializeField] private Color _victoryColor;
        [SerializeField] private Color _defeatColor;

        private InputField inputName;
        private void Start()
        {
            var endText = GetComponent<Text>();
            endText.text = GlobalData.instance.IsVictory ? _victoryText : _defeatText;
            endText.color = GlobalData.instance.IsVictory ? _victoryColor : _defeatColor;
        }
    }
}