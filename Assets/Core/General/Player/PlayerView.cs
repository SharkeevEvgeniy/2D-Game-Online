using Photon.Pun;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(PhotonView))]
public class PlayerView : MonoBehaviour
{
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
            _playerService.SetPlayerView(this);
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
