using Zenject;
using App.PlayerInput;

public class PlayerInputInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<PlayerInputService>().AsSingle().NonLazy();
    }
}