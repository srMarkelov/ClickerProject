using System;
using System.Collections;
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
        [Inject] private StorageHandler _storageHandler;
        
        private IEnemy _currentEnemy;
        private int _rewardCurrentEnemy;
        
       // private readonly BoolReactiveProperty _currentEnemyDead = new BoolReactiveProperty();

       // public IReadOnlyReactiveProperty<bool> CurrentEnemyDead => _currentEnemyDead;


        private void Start()
        {
            _enemySpawner.SpawnEnemy();
        }

        public void SetCurrentEnemy(IEnemy currentEnemy)
        {
            _currentEnemy = currentEnemy;
            _rewardCurrentEnemy = _currentEnemy.RewardGold;
            SubscribeToHealthEnemy();
        }

        private void SubscribeToHealthEnemy()
        {
            _currentEnemy.Health
                .Where(_ => _ <= 0)
                .Subscribe(_ =>
                {
                    StartCoroutine("DeadCurrentEnemy");
                });
        }
        private void LevelComplete()
        {
            _levelHandler.LevelComplete();
            Debug.Log("LevelComplete");
        }
        
        private IEnumerator DeadCurrentEnemy()
        {
            _storageHandler.AddReward(_rewardCurrentEnemy);
            LevelComplete();
            Debug.Log("Умер");
            // _currentEnemyDead.Value = true;
            _currentEnemy = null;
            yield return new WaitForSeconds(1f);
            _enemySpawner.SpawnEnemy();
        }
    }
}
