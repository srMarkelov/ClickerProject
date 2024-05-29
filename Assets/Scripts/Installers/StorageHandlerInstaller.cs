using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class StorageHandlerInstaller : MonoInstaller
{
    [SerializeField] private StorageHandler storageHandler;
    public override void InstallBindings()
    {
        Container.Bind<StorageHandler>().FromInstance(storageHandler).AsSingle();
        Container.QueueForInject(storageHandler);
    }
}
