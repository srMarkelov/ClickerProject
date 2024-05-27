using Core.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Core.Game
{
    public class ClickArea : MonoBehaviour,IPointerDownHandler
    {
        [Inject] private PlayerHandler _player;
        
        
        public void OnPointerDown(PointerEventData eventData)
        {
            _player.Attack();
        }
    }
}
