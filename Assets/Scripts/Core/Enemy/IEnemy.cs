using UniRx;

namespace Core.Enemy
{
    public interface IEnemy
    {
        public int Health { get; set; }
        public int RewardGold { get; set; }
        public void SetHealth(int health);
        public void TakeDamage(int valueDamage);
        public void Death();
    }
}