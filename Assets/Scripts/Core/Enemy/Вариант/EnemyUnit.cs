using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace Core.Enemy
{
    public class EnemyUnit : EnemyBase
    {
        private bool _deathEnemy;


        private void Awake()
        {
            Init();
        }

        public override void Init()
        {
            Health = new IntReactiveProperty();
            EnemyType = EnemyType.EnemyUnit;
        }

        public override void SetHealth(int health)
        {
            Health.Value = health;
        }

        public override void SetReward(int gold)
        {
            RewardGold = gold;
        }

        public void SetRewardGold(int gold)
        {
            RewardGold = gold;
        }

        public override void TakeDamage(int valueDamage)
        {
            if (_deathEnemy)
                return;

            Health.Value -= valueDamage;
            if (Health.Value <= 0)
            {
                Death();
            }
        }

        public override void Death()
        {
            _deathEnemy = true;
            OnDeath?.Invoke();
            Debug.Log("EnemyUnit Died");
        }
    }
}