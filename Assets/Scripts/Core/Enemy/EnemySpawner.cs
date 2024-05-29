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
        [Inject] private DiContainer _diContainer;

        private IEnemy _currentEnemy;
        
        private readonly BoolReactiveProperty _currentEnemyDead = new BoolReactiveProperty();

        public IReadOnlyReactiveProperty<bool> CurrentEnemyDead => _currentEnemyDead;
        

        private void Start()
        {
            SpawnEnemy();
        }
        
        private void SpawnEnemy()
        {
            _currentEnemyDead.Value = false;
            
            var enemy = _diContainer.InstantiatePrefab(CreateNewEnemy(DefineLevelType()), transform.position, Quaternion.identity, null);
            _currentEnemy = enemy.GetComponent<IEnemy>();
            _enemyFactory.SetHealthCurrentEnemy(_currentEnemy,_levelHandler.CurrentLevel.Value);
            
            _currentEnemy.Health
                .Where(_ => _ <= 0)
                .Subscribe(_ =>
                {
                    StartCoroutine("DeadCurrentEnemy");
                });
            
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
        
        private IEnumerator DeadCurrentEnemy()
        {
            Debug.Log("Умер");
            _currentEnemyDead.Value = true;
            _currentEnemy = null;
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }

        public IEnemy GetCurrentEnemy()
        {
            return _currentEnemy;
        }
        
        private bool DefineLevelType()
        {
            bool bossLevel = false;
            if (IsDivisibleByTen(_levelHandler.CurrentLevel.Value))
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
