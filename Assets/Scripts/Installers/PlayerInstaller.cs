using Core.Player;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerHandler playerHandler;
        public override void InstallBindings()
        {
            Container.Bind<PlayerHandler>().FromInstance(playerHandler).AsSingle();
            Container.QueueForInject(playerHandler);
        }
    }
}