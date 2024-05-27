using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Enemy
{
    public class EnemyUnit :MonoBehaviour, IEnemy
    {
        [Inject] private EnemySpawnerFactory _enemySpawnerFactory;
        public int Health { get; set; }
        public int RewardGold { get; set; }
        private bool _deathEnemy;
        

        public void SetHealth(int health)
        {
            Health = health;
        }
        public void SetRewardGold(int gold)
        {
            RewardGold = gold;
        }

        public void TakeDamage(int valueDamage)
        {
            if(_deathEnemy)
                return;
            
            Health -= valueDamage;
            if (Health <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            _deathEnemy = true;
            _enemySpawnerFactory.DeadCurrentEnemy();
            Debug.Log("BobikSdoh");
            Destroy(gameObject);
        }
    }
}
