using Core.PlayerAssistance;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class AssistanceSpawnerInstaller : MonoInstaller
    {
        [SerializeField] private AssistanceSpawner assistanceSpawner;

        public override void InstallBindings()
        {
            Container.Bind<AssistanceSpawner>().FromInstance(assistanceSpawner).AsSingle();
            Container.QueueForInject(assistanceSpawner);
        }
    }
}
