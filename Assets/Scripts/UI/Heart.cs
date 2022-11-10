using System;
using System.Collections.Generic;
using Interface;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Heart : MonoBehaviour, IControllableAnimation
    {
        [SerializeField] private List<Sprite> _hearts;
        private Image _heart;
        
        [SerializeField] private float _baseSpeed = 10;
        [SerializeField] private float _speedMultiplier = 1.3f;
        
        private float _speed = 1;
        private float _timer = 1;
        private int _index = 0;
        
        private void Start()
        {
            _speed = _baseSpeed;
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

        public void SpeedUp() => _speed *= _speedMultiplier;
        
        private void UpdateHeartSprite() => _heart.sprite = _hearts[_index];
    }
}