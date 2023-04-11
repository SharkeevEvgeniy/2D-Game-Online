using App.Network;
using Zenject;
using Photon.Pun;
using UnityEngine;

public class GameNetworkService : IInitializable
{
    public GameNetworkService(PlayerNetworkFactoryService playerNetworkFactoryService,
                              PlayerSettings playerSettings)
    {
        _playerNetworkFactoryService = playerNetworkFactoryService;
        _playerSettings = playerSettings;
    }

    private PlayerNetworkFactoryService _playerNetworkFactoryService;
    private PlayerSettings _playerSettings;

    public void Initialize()
    {
        int side = PhotonNetwork.CurrentRoom.PlayerCount % 2;
        if (side == 0)
            side = -1;

        Vector2 startPosition = Vector2.zero + (Vector2.right * _playerSettings.StartPositionOffset * side);

        _playerNetworkFactoryService.Spawn(startPosition, Quaternion.identity);
    }
}
