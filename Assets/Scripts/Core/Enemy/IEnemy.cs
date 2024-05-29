using UniRx;

namespace Core.Enemy
{
    public interface IEnemy
    {
        public IntReactiveProperty Health { get; set; }
        public EnemyType EnemyType{ get; set; }
        public int RewardGold { get; set; }
        public void SetHealth(int health);
        public void TakeDamage(int valueDamage);
        public void Death();
    }

    
}
