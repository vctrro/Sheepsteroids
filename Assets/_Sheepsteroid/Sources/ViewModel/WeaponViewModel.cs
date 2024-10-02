using System;
using UnityEngine;
using UnityEngine.Pool;
using Model;
using static UnityEditor.Experimental.GraphView.GraphView;

public class WeaponViewModel
{
    public event Action<int> OnLaserCapacityChanged;

    private IPlayer _player;
    private InputController _inputs;
    private GameSettings _gameSettings;
    private SingleGun<LaserGun, ILaser, ILaserView> _laserGun;
    private MultiGun<BulletGun, IBullet, IBulletView> _bulletGun;

    public float LaserRollbackTime => _laserGun.Gun.RollbackTime;

    public WeaponViewModel(
        GameSettings gameSettings,
        ViewModelPair<IPlayer, IPlayerView> playerViewModel,
        InputController inputs)
    {
        _player = playerViewModel.Model;
        _inputs = inputs;
        _gameSettings = gameSettings;
        _bulletGun = new MultiGun<BulletGun, IBullet, IBulletView>(
            new BulletGun(),
            new BulletFactory(_gameSettings));
        _laserGun = new SingleGun<LaserGun, ILaser, ILaserView>(
            new LaserGun(),
            new LaserFactory(_gameSettings, playerViewModel));

        Start();
    }

    private void Start()
    {
        _laserGun.Gun.Init(
            _gameSettings.Weapon.LaserGunCapacity,
            _gameSettings.Weapon.LaserGunRollbackTime);
        _laserGun.Gun.OnCapacityChanged =
            (count) => { OnLaserCapacityChanged?.Invoke(count); };

        _inputs.OnShoot += BulletShoot;
        _inputs.OnLaserShoot += LaserShoot;
        _gameSettings.OnGameQuit += OnDestroy;
    }

    public void BulletShoot()
    {
        var bulletGun = _bulletGun.GetGun(
            _player.Position,
            _player.Rotation,
            _gameSettings.Weapon.BulletLifeTime);
        (bulletGun.Projectile as IMovable).Speed = _gameSettings.Weapon.BulletSpeed;
        _player.Gun = bulletGun;
        _player.Gun.Shoot();
    }

    public void LaserShoot()
    {
        _player.Gun = _laserGun.GetGun(
            _player.Position,
            _player.Rotation,
            _gameSettings.Weapon.LaserLifeTime);

        _player.Gun.Shoot();
    }

    private void OnDestroy()
    {
        _inputs.OnShoot -= BulletShoot;
        _inputs.OnLaserShoot -= LaserShoot;
        _gameSettings.OnGameQuit -= OnDestroy;
    }
}

