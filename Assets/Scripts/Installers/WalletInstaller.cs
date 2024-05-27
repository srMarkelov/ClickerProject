using Core.UI.Wallet;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class WalletInstaller : MonoInstaller
    {
        [SerializeField] private WallerHandler wallerHandler;
        public override void InstallBindings()
        {
            Container.Bind<WallerHandler>().FromInstance(wallerHandler).AsSingle();
            Container.QueueForInject(wallerHandler);
        }
    }
}
