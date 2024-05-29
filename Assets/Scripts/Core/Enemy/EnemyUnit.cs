using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Enemy
{
    public class EnemyUnit :MonoBehaviour, IEnemy
    {
        public IntReactiveProperty Health { get; set; }
        public EnemyType EnemyType { get; set; }
        public int RewardGold { get; set; }
        private bool _deathEnemy;

        private void Awake()
        {
            Health = new IntReactiveProperty();
            EnemyType = EnemyType.EnemyUnit;
        }

        public void SetHealth(int health)
        {
            Health.Value = health;
        }
        public void SetRewardGold(int gold)
        {
            RewardGold = gold;
        }

        public void TakeDamage(int valueDamage)
        {
            if(_deathEnemy)
                return;
            
            Health.Value -= valueDamage;
            if (Health.Value <= 0)
            {
                Death();
            }
        }

        public void Death()
        {
            _deathEnemy = true;
            Debug.Log("BobikSdoh");
            Destroy(gameObject);
        }
    }
}
