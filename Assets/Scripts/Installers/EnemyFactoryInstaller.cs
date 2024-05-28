using UnityEngine;
using Zenject;

namespace Installers
{
    public class EnemyFactoryInstaller : MonoInstaller
    {
        [SerializeField] private EnemyFactory enemyFactory;
        public override void InstallBindings()
        {
            Container.Bind<EnemyFactory>().FromInstance(enemyFactory).AsSingle();
            Container.QueueForInject(enemyFactory);
        }
    }
}
