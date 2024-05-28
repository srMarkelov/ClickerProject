using System;
using Core.Player;
using UniRx;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [Inject] private PlayerHandler _playerHandler;
        [Inject] private EnemyFactory _enemyFactory;
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
            var enemy = _diContainer.InstantiatePrefab(_enemyFactory.CreateNewEnemy(), transform.position, Quaternion.identity, null);
            var _currentEnemy = enemy.GetComponent<IEnemy>();
            SetHealthCurrentEnemy(_currentEnemy);
            _currentEnemy.Health
                .Where(_ => _ <= 0)
                .Subscribe(_ =>
            {
                Debug.Log("Умер");
                _currentEnemyDead.Value = true;
                Invoke("DeadCurrentEnemy",0.75f);
            });
            
            _playerHandler.SerCurrentEnemy(_currentEnemy);
        }

        private void SetHealthCurrentEnemy(IEnemy currentEnemy)
        {
            var randomHealth = Random.Range(1, 5);
            currentEnemy.SetHealth(randomHealth); 
        }

        public void DeadCurrentEnemy()
        {
            _currentEnemy = null;
            Invoke("SpawnEnemy", 1.5f);
        }

        public IEnemy GetCurrentEnemy()
        {
            return _currentEnemy;
        }
    }
}
