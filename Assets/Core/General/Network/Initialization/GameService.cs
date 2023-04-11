using App.Network;
using Zenject;

public class GameService : IInitializable
{
    public GameService(PlayerNetworkFactoryService playerNetworkFactoryService)
    {
        _playerNetworkFactoryService = playerNetworkFactoryService;
    }

    private PlayerNetworkFactoryService _playerNetworkFactoryService;

    public void Initialize()
    {
        _playerNetworkFactoryService.Spawn();
    }
}
