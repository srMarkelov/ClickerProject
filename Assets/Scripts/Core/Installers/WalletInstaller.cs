using Core.UI.Wallet;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class WalletInstaller : MonoInstaller
    {
        [SerializeField] private WalletStorage walletStorage;
        public override void InstallBindings()
        {
            Container.Bind<WalletStorage>().FromInstance(walletStorage).AsSingle();
            Container.QueueForInject(walletStorage);
        }
    }
}
