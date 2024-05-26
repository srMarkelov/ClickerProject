using System;
using System.Collections.ObjectModel;
using Core.Player;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using Zenject;

namespace Core.PlayerAssistaince
{
    public class AssistanceSpawnerFactory : MonoBehaviour
    {
        private PlayerUnit _playerUnit;

        [Inject] 
        private void Construct(PlayerUnit playerUnit)
        {
            _playerUnit = playerUnit;
        }
        
        private void Start()
        {
            _playerUnit.StartGame();
        }
    }
}
