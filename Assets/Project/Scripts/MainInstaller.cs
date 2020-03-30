using UnityEngine;
using Zenject;

public class MainInstaller : Installer<MainInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        // Container.Bind<Greeter>().AsSingle().NonLazy();
    }
}