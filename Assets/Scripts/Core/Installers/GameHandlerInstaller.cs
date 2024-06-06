using Core.Game;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class GameHandlerInstaller : MonoInstaller
    {
        [SerializeField] private GameHandler gameHandler;

        public override void InstallBindings()
        {
            Container.Bind<GameHandler>().FromInstance(gameHandler).AsSingle();
            Container.QueueForInject(gameHandler);
        }
    }
}
