using TMPro;
using UniRx;
using UnityEngine;

namespace Core.Game
{
    public class StorageHandler : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        private readonly IntReactiveProperty _goldInStorage = new IntReactiveProperty();
        public IReactiveProperty<int> GoldInStorage => _goldInStorage;

        public void AddReward(int gold)
        {
            _goldInStorage.Value += gold;
            goldText.text = _goldInStorage.Value.ToString();
        }

        public void RemoveGold(int gold)
        {
            if (_goldInStorage.Value < gold)
                return;

            _goldInStorage.Value -= gold;
            goldText.text = _goldInStorage.Value.ToString();
        }
    }
}