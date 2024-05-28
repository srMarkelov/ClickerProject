using Core.Enemy;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawner enemySpawner;

        public override void InstallBindings()
        {
            Container.Bind<EnemySpawner>().FromInstance(enemySpawner).AsSingle();
            Container.QueueForInject(enemySpawner);
        }
    }
}
