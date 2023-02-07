using UnityEngine;

[System.Serializable]
public class WeaponSettings
{
    //[Header("Bullet")]
    [SerializeField] private float _bulletSpeed = 80.0f;
    [SerializeField] private float _bulletLifeTime = 1.0f;
    [Space(10)]
    //[Header("Laser")]
    [SerializeField] private float _laserLifeTime = 0.5f;
    [SerializeField] private int _laserGunCapacity = 3;
    [SerializeField] private float _laserGunRollbackTime = 3.0f;

    public float BulletSpeed { get => _bulletSpeed; }
    public float BulletLifeTime { get => _bulletLifeTime; }
    public float LaserLifeTime { get => _laserLifeTime; }
    public int LaserGunCapacity { get => _laserGunCapacity; }
    public float LaserGunRollbackTime { get => _laserGunRollbackTime; }
}

