using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Enemy
{
    public class EnemyFactory : MonoBehaviour
    {
        [Inject] private PlayerHandler _playerHandler;

        public void SetHealthCurrentEnemy(EnemyBase enemyBase, int currentLevel)
        {
            var playerAttackPower = _playerHandler.GetAttackPower();

            if (enemyBase.EnemyType == EnemyType.EnemyBoss)
            {
                var randomBaseHealth = Random.Range(3, 5);
                var healthEnemy = randomBaseHealth * playerAttackPower * currentLevel;
                enemyBase.SetHealth(healthEnemy);
            }
            else
            {
                var randomBaseHealth = Random.Range(1, 3);
                var healthEnemy = randomBaseHealth * playerAttackPower * currentLevel;
                enemyBase.SetHealth(healthEnemy);
            }
        }

        public void SetRewardCurrentEnemy(EnemyBase enemyBase, int currentLevel)
        {
            if (enemyBase.EnemyType == EnemyType.EnemyBoss)
            {
                var randomBaseReward = Random.Range(3, 5);
                var rewardEnemy = randomBaseReward * currentLevel;
                Debug.Log(rewardEnemy);
                enemyBase.SetReward(rewardEnemy);
            }
            else
            {
                var randomBaseReward = Random.Range(1, 3);
                var rewardEnemy = randomBaseReward * currentLevel;
                enemyBase.SetReward(rewardEnemy);
            }
        }
    }
}