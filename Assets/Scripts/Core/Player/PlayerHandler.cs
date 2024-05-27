using System;
using Core.Enemy;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Core.Player
{
    public class PlayerHandler : MonoBehaviour
    {
        private IEnemy _currentEnemy;
        public void SerCurrentEnemy(IEnemy enemy)
        {
            _currentEnemy = enemy;
        }

        public void Attack()
        {
            _currentEnemy.TakeDamage(1);
            Debug.Log("Attack");
        }
    }
}
