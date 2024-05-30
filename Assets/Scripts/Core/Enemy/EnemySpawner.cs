using System;
using System.Collections;
using System.Collections.Generic;
using Core.Game;
using Core.Player;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;
        [SerializeField] private GameObject enemyBossPrefab;
        
        [Inject] private PlayerHandler _playerHandler;
        [Inject] private EnemyFactory _enemyFactory;
        [Inject] private LevelHandler _levelHandler;
        [Inject] private GameHandler _gameHandler;
        [Inject] private DiContainer _diContainer;

        private IEnemy _currentEnemy;
        
        
        public void SpawnEnemy()
        {
            var enemy = _diContainer.InstantiatePrefab(CreateNewEnemy(DefineLevelType()), transform.position, Quaternion.identity, null);
            _currentEnemy = enemy.GetComponent<IEnemy>();
            _enemyFactory.SetHealthCurrentEnemy(_currentEnemy,_levelHandler.CurrentLevel.Value);
            _enemyFactory.SetRewardCurrentEnemy(_currentEnemy,_levelHandler.CurrentLevel.Value);
            
            _gameHandler.SetCurrentEnemy(_currentEnemy);
            _playerHandler.SerCurrentEnemy(_currentEnemy);
        }

        private GameObject CreateNewEnemy(bool enemyBoss)
        {
            if (enemyBoss)
            {
                Debug.Log("Враг-Босс");
                var newBossEnemy = enemyBossPrefab;
                return newBossEnemy;
            }
         
            Debug.Log("Обычный враг");
            var newEnemy = enemyPrefab;
            return newEnemy;
        }
        
        

        public IEnemy GetCurrentEnemy()
        {
            return _currentEnemy;
        }
        
        private bool DefineLevelType()
        {
            bool bossLevel = false;
            if (IsDivisibleByTen(_levelHandler.CurrentLevel.Value) && _levelHandler.CurrentLevel.Value != 0)
            {
                return bossLevel = true;
            }
            return bossLevel = false;
        }
        
        private bool IsDivisibleByTen(int number)
        {
            return number % 10 == 0;
        }
    }
}
