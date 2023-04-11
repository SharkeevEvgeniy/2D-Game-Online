using Zenject;
using App.Network;

public class PlayerInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerService>().AsSingle();
        Container.Bind<PlayerNetworkFactoryService>().AsSingle();
    }
}