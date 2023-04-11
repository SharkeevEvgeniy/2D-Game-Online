using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
{
    [SerializeField] private PlayerSettings _playerSettings;

    public override void InstallBindings()
    {
        Container
            .Bind<PlayerSettings>()
            .FromInstance(_playerSettings)
            .AsSingle()
            .NonLazy();
    }
}