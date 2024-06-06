using System.Collections;
using System.Collections.Generic;
using Core.Game;
using UnityEngine;
using Zenject;

public class LevelHandlerInstaller : MonoInstaller
{
    [SerializeField] private LevelHandler levelHandler;

    public override void InstallBindings()
    {
        Container.Bind<LevelHandler>().FromInstance(levelHandler).AsSingle();
        Container.QueueForInject(levelHandler);
    }
}
