using System;
using UniRx;
using UnityEngine;

namespace Core.Enemy
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public IntReactiveProperty Health;
        public EnemyType EnemyType;
        public int RewardGold;
        public Action OnDeath;
        public abstract void Init();
        public abstract void SetHealth(int health);
        public abstract void SetReward(int gold);
        public abstract void TakeDamage(int valueDamage);
        public abstract void Death();
    }
}