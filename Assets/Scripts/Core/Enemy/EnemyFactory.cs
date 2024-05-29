using System.Collections;
using System.Collections.Generic;
using Core.Enemy;
using Core.Game;
using Core.Player;
using UnityEngine;
using Zenject;
using Zenject.Asteroids;

public class EnemyFactory : MonoBehaviour
{
    [Inject] private PlayerHandler _playerHandler;
    public void SetHealthCurrentEnemy(IEnemy enemy, int currentLevel)
    {
        var playerAttackPower = _playerHandler.GetAttackPower();
        
        if (enemy.EnemyType == EnemyType.EnemyBoss)
        {
            var randomBaseHealth = Random.Range(3, 5);
            var healthEnemy = randomBaseHealth * playerAttackPower * currentLevel;
            enemy.SetHealth(healthEnemy); 
        }
        else
        {
            var randomBaseHealth = Random.Range(1, 3);
            var healthEnemy = randomBaseHealth * playerAttackPower * currentLevel;
            enemy.SetHealth(healthEnemy); 
        }
    }
    
}
