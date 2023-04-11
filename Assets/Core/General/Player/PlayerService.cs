using System;
using UnityEngine;
using Photon.Pun;
using Zenject;

namespace App
{
    public class PlayerService : IInitializable
    {
        public PlayerService(BulletFactoryService bulletFactoryService,
                             PlayerSettings playerSettings)
        {
            _bulletFactoryService = bulletFactoryService;
            _playerSettings = playerSettings;
        }

        public int Health { get => _health; }
        private int _health;

        private PlayerView _playerView;

        private BulletFactoryService _bulletFactoryService;
        private PlayerSettings _playerSettings;

        public void Initialize()
        {
            _health = _playerSettings.Health;
        }

        public void SetPlayerView(PlayerView playerView)
        {
            _playerView = playerView ?? throw new ArgumentNullException(nameof(playerView));
        }

        public void TryApplyDamage(int damage)
        {
            _health -= damage;

            if(_health <= 0)
            {
                _health = 0;
                Die();
            }
        }

        public void Move(Vector2 direction)
        {
            if (_playerView == null)
                return;

            _playerView.Move(direction);
        }

        public void Shoot()
        {
            _bulletFactoryService.Spawn(_playerView.GetPosition(), _playerView.GetRotation());
        }

        private void Die()
        {
            PhotonNetwork.Destroy(_playerView.PhotonView);
            _health = _playerSettings.Health;
        }
    }
}
