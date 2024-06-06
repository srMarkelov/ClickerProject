using System;
using Core.Enemy;
using UniRx;
using UniRx.Triggers;
using Unity.VisualScripting;
using UnityEngine;

namespace Core.Player
{
    public class PlayerHandler : MonoBehaviour
    {
        [SerializeField] private int attackPower = 2;

        private EnemyBase _currentEnemyBase;


        public void SerCurrentEnemy(EnemyBase enemyBase)
        {
            _currentEnemyBase = enemyBase;
        }

        public void Attack()
        {
            _currentEnemyBase.TakeDamage(attackPower);
            Debug.Log("Attack");
        }

        public int GetAttackPower()
        {
            return attackPower;
        }
    }
}