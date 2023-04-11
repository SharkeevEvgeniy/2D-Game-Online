using Zenject;
using App.Input;

public class PlayerInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerInputService>().AsSingle();
    }
}