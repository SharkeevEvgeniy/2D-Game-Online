using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerService
{
    private PlayerView _playerView;

    public void SetPlayerView(PlayerView playerView)
    {
        _playerView = playerView;
    }

    public void Move(Vector2 direction)
    {

    }

    public void Shoot()
    {

    }
}
