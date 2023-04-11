using UnityEngine;
using Zenject;

public class BulletView : MonoBehaviour
{
    public int Damage { get => _bullet.Damage; }
    
    private IBullet _bullet;
    private PlayerSettings _playerSettings;

    [Inject]
    private void Construct(IBullet bullet, PlayerSettings playerSettings)
    {
        _bullet = bullet;
        _playerSettings = playerSettings;
    }

    public void Move(Vector2 direction)
    {
        transform.Translate(direction * _playerSettings.BulletVelocity * Time.deltaTime);
    }
}
