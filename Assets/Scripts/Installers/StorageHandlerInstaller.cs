using Core.Game;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class StorageHandlerInstaller : MonoInstaller
    {
        [SerializeField] private StorageHandler storageHandler;
        public override void InstallBindings()
        {
            Container.Bind<StorageHandler>().FromInstance(storageHandler).AsSingle();
            Container.QueueForInject(storageHandler);
        }
    }
}
