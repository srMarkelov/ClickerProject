using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject.Asteroids;

namespace Core.Game
{
    public class LevelHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI levelText;

        private readonly IntReactiveProperty _currentLevel = new IntReactiveProperty();
        public IReadOnlyReactiveProperty<int> CurrentLevel => _currentLevel;

        private void Awake()
        {
            if (_currentLevel.Value <= 0)
            {
                _currentLevel.Value = 1;
            }
        }

        private void Start()
        {
            SetCurrentLevel(1);
        }

        public void LevelComplete()
        {
            _currentLevel.Value++;
            levelText.text = CurrentLevel.Value.ToString();
        }

        public void SetCurrentLevel(int level)
        {
            _currentLevel.Value = level;
            levelText.text = CurrentLevel.Value.ToString();
        }
    }
}