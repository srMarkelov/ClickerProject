using System;
using Core.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Core.Enemy
{
    public class EnemySpawnerFactory : MonoBehaviour
    {
        [SerializeField] private GameObject enemyPrefab;

        [Inject] private PlayerHandler _playerHandler;
        [Inject] private DiContainer _diContainer;

        private IEnemy _currentEnemy;
        
        private void Start()
        {
            SpawnEnemy();
        }

        private void SpawnEnemy()
        {
            var enemy = _diContainer.InstantiatePrefab(enemyPrefab, transform.position, Quaternion.identity, null);
            var _currentEnemy = enemy.GetComponent<IEnemy>();
            SetHealthCurrentEnemy(_currentEnemy);
            
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
            Invoke("SpawnEnemy", 0.5f);
        }
    }
}
