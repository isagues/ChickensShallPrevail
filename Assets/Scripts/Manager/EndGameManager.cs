using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class EndGameManager : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Sprite _victorySprite;
        [SerializeField] private Sprite _defeatSprite;

        private InputField inputName;
        private void Start()
        {
            GetComponent<Image>().sprite = GlobalData.instance.IsVictory ? _victorySprite : _defeatSprite;
        }
    }
}