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

        private EnemyBase _currentEnemyBase;


        public void SpawnEnemy()
        {
            var enemy = _diContainer.InstantiatePrefab(CreateNewEnemy(DefineLevelType()), transform.position,
                Quaternion.identity, null);
            _currentEnemyBase = enemy.GetComponent<EnemyBase>();
            _currentEnemyBase.Init();
            _currentEnemyBase.OnDeath += DeathCurrentEnemy;
            _enemyFactory.SetHealthCurrentEnemy(_currentEnemyBase, _levelHandler.CurrentLevel.Value);
            _enemyFactory.SetRewardCurrentEnemy(_currentEnemyBase, _levelHandler.CurrentLevel.Value);

            _gameHandler.SetCurrentEnemy(_currentEnemyBase);
            _playerHandler.SerCurrentEnemy(_currentEnemyBase);
        }

        private GameObject CreateNewEnemy(bool enemyBoss)
        {
            if (enemyBoss)
            {
                var newBossEnemy = enemyBossPrefab;
                return newBossEnemy;
            }

            var newEnemy = enemyPrefab;
            return newEnemy;
        }


        public EnemyBase GetCurrentEnemy()
        {
            return _currentEnemyBase;
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

        private void DeathCurrentEnemy()
        {
            _currentEnemyBase.OnDeath -= DeathCurrentEnemy;
            Destroy(_currentEnemyBase.gameObject);
        }
    }
}