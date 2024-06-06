using System;
using System.Collections;
using Core.Enemy;
using DG.Tweening;
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

        private EnemyBase _currentEnemyBase;
        private int _rewardCurrentEnemy;

        // private readonly BoolReactiveProperty _currentEnemyDead = new BoolReactiveProperty();

        // public IReadOnlyReactiveProperty<bool> CurrentEnemyDead => _currentEnemyDead;


        private void Start()
        {
            _enemySpawner.SpawnEnemy();
        }

        public void SetCurrentEnemy(EnemyBase currentEnemyBase)
        {
            _currentEnemyBase = currentEnemyBase;
            _rewardCurrentEnemy = _currentEnemyBase.RewardGold;
            SubscribeToHealthEnemy();
        }

        private void SubscribeToHealthEnemy()
        {
            _currentEnemyBase.Health
                .Where(_ => _ <= 0)
                .Subscribe(_ =>
                {
                    DOVirtual.DelayedCall(1, DeadCurrentEnemy);
                });
        }
        private void LevelComplete()
        {
            _levelHandler.LevelComplete();
            Debug.Log("LevelComplete");
        }

        private void DeadCurrentEnemy()
        {
            _storageHandler.AddReward(_rewardCurrentEnemy);
            LevelComplete();
            _currentEnemyBase = null;
            _enemySpawner.SpawnEnemy();
        }
    }
}