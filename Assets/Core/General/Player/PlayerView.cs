using Photon.Pun;
using UnityEngine;
using Zenject;

namespace App
{
    [RequireComponent(typeof(PhotonView))]
    public class PlayerView : MonoBehaviour
    {
        public PhotonView PhotonView { get => _photonView; }

        private PhotonView _photonView;

        private PlayerService _playerService;

        [Inject]
        private void Construct(PlayerService playerService)
        {
            _playerService = playerService;
        }

        private void Awake()
        {
            _photonView = GetComponent<PhotonView>();
        }

        private void Start()
        {
            if (_photonView.IsMine)
            {
                _playerService.SetPlayerView(this);
            }
        }

        public void Move(Vector2 direction)
        {
            transform.Translate(direction * Time.deltaTime * 0.1f, Space.World);

            if (direction != Vector2.zero)
            {
                Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 700f);
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.TryGetComponent<BulletView>(out BulletView bullet))
            {

            }
        }

        public Vector2 GetPosition() => transform.position;

        public Quaternion GetRotation() => transform.localRotation;
    }
}
