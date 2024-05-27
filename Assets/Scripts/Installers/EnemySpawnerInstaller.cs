using Core.Enemy;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [FormerlySerializedAs("enemySpawner")] [SerializeField] private EnemySpawnerFactory enemySpawnerFactory;

        public override void InstallBindings()
        {
            Container.Bind<EnemySpawnerFactory>().FromInstance(enemySpawnerFactory).AsSingle();
            Container.QueueForInject(enemySpawnerFactory);
        }
    }
}
