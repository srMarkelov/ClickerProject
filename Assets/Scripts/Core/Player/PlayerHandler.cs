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
        
        private IEnemy _currentEnemy;

        
        public void SerCurrentEnemy(IEnemy enemy)
        {
            _currentEnemy = enemy;
        }

        public void Attack()
        {
            _currentEnemy.TakeDamage(attackPower);
            Debug.Log("Attack");
        }
        
        public int GetAttackPower()
        {
            return attackPower;
        }
    }
}
