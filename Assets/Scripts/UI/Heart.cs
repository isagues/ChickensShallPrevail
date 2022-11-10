using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Heart : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _hearts;
        private Image _heart;
        
        [SerializeField] private float _speed = 10;
        private float _timer = 1;
        private int _index = 0;
        
        private void Start()
        {
            _heart = GetComponent<Image>();
            UpdateHeartSprite();
        }

        private void Update()
        {
            _timer -= Time.deltaTime * _speed;

            if (!(_timer <= 0)) return;

            _index = (_index + 1) % _hearts.Count;
            UpdateHeartSprite();
            _timer = 1;

        }
        
        private void UpdateHeartSprite() => _heart.sprite = _hearts[_index];
    }
}