public class Bullet : IBullet
{
    public Bullet(PlayerSettings playerSettings)
    {
        _playerSettings = playerSettings;
    }

    public int Damage => _playerSettings.Damage;

    private PlayerSettings _playerSettings;
}
