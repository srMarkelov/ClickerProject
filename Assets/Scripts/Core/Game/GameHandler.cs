using System;
using Core.Enemy;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Game
{
    public class GameHandler : MonoBehaviour
    {
        [Inject] private EnemySpawner _enemySpawner;
        [Inject] private LevelHandler _levelHandler;

        private void Start()
        {
            _enemySpawner.GetCurrentEnemy();
            _enemySpawner.CurrentEnemyDead
                .Where(_ => _ == true)
                .Subscribe(_ => LevelComplete());
        }

        private void LevelComplete()
        {
            _levelHandler.LevelComplete();
            Debug.Log("LevelComplete");
        }
        
    }
}
