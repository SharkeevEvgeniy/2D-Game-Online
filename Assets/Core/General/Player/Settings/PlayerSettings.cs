using UnityEngine;

[CreateAssetMenu(fileName = "PlayerSettings", menuName = "Settings/PlayerSettings")]
public class PlayerSettings : ScriptableObject
{
    public int PlayerVelocity { get => _playerVelocity; }
    public int BulletVelocity { get => _bulletVelocity; }
    public int Health { get => _health; }
    public int Damage { get => _damage; }
    public int StartPositionOffset { get => _startPositionOffset; }

    [SerializeField] private int _playerVelocity;
    [SerializeField] private int _bulletVelocity;
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private int _startPositionOffset;
}
