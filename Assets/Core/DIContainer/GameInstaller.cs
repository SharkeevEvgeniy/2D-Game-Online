using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<IInitializable>()
            .To<GameService>()
            .AsSingle()
            .NonLazy();
    }
}