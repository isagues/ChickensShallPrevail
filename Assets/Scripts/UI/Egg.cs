using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Egg : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _eggs;
        private Image _egg;
        
        private int _index = 0;
        
        private void Start()
        {
            _egg = GetComponent<Image>();
            _egg.sprite = _eggs[_index];
        }

        private void Update()
        {
            
        }
    }
}