using System;
using UnityEngine;
using UnityEngine.Pool;
using Model;

public class EnemiesViewModel
{
    public event Action ActiveEnemyDied;
    public event Action SplittableEnemyDied;
    public event Action FragmentEnemyDied;

    private GameSettings _gameSettings;
    private ViewModelSpawner<IEnemy, IEnemyView> _activeSpawner;
    private ViewModelSpawner<IEnemy, IEnemyView> _fragmentSpawner;
    private ViewModelSpawner<ISplittableEnemy, IEnemyView> _splittableSpawner;
    private IPlayer _player;
    private Timer _timerActive;
    private Timer _timerSplittable;
    private int _enemyFragments;

    private float RandomRotation => UnityEngine.Random.Range(0, 360);
    private Vector2 RandomPosition =>
        UnityEngine.Random.insideUnitCircle.normalized +
        new Vector2(_gameSettings.BorderControl.Right, _gameSettings.BorderControl.Top);

    public int Points { get; private set; }

    public EnemiesViewModel(GameSettings gameSettings, IPlayer player)
    {
        _gameSettings = gameSettings;
        _player = player;

        _enemyFragments = _gameSettings.Prefabs.EnemyFragments.Length;
        _activeSpawner = new ViewModelSpawner<IEnemy, IEnemyView>(
            new ActiveEnemyFactory(gameSettings, _player));
        _fragmentSpawner = new ViewModelSpawner<IEnemy, IEnemyView>(
            new FragmentEnemyFactory(gameSettings, _enemyFragments));
        _splittableSpawner = new ViewModelSpawner<ISplittableEnemy, IEnemyView>(
            new SplittableEnemyFactory(gameSettings));

        Start();
    }

    private void Start()
    {
        _gameSettings.OnGameQuit += OnDestroy;
        SpawnersInitialise();
    }

    private void SpawnersInitialise()
    {
        _timerActive = new Timer();
        _timerActive.Start(_gameSettings.ActiveEnemy.TimeToSpawn, true);
        _timerActive.OnTimerFinish += SpawnActiveEnemy;
        _timerSplittable = new Timer();
        _timerSplittable.Start(_gameSettings.PassiveEnemy.TimeToSpawn, true);
        _timerSplittable.OnTimerFinish += SpawnSplittableEnemy;
    }

    private void SpawnActiveEnemy()
    {
        if (_activeSpawner.Count >=
            _gameSettings.ActiveEnemy.MaxQuantity) return;

        var activeEnemy = _activeSpawner.Get;
        var model = activeEnemy.Model;
        model.Speed = RandomSpeed(_gameSettings.ActiveEnemy.Speed);
        model.Init(RandomPosition);
        activeEnemy.Model.OnCollisionWithProjectile = OnEnemyDied;
    }

    private void SpawnSplittableEnemy()
    {
        if (_splittableSpawner.Count >=
            _gameSettings.PassiveEnemy.MaxQuantity) return;

        var splittableEnemy = _splittableSpawner.Get;
        var model = splittableEnemy.Model;
        model.Init(RandomPosition, RandomRotation);
        model.Speed = RandomSpeed(_gameSettings.PassiveEnemy.Speed);
        model.OnCollisionWithProjectile = OnEnemyDied;
        model.OnSplit = SpawnFragment;
        model.Move();
    }

    private void SpawnFragment(IEnemy splittable)
    {
        for (int i = 0; i < _enemyFragments; i++)
        {
            var fragmentEnemy = _fragmentSpawner.Get;
            var model = fragmentEnemy.Model;
            model.Init(splittable.Position, RandomRotation);
            model.Speed = RandomSpeed(splittable.Speed * 2);
            model.OnCollisionWithProjectile = OnEnemyDied;
            model.Move();
        }
    }

    private void OnEnemyDied(IEnemy enemy)
    {
        switch (enemy)
        {
            case  ActiveEnemy:
                ActiveEnemyDied?.Invoke();
                break;
             case  SplittableEnemy:
                SplittableEnemyDied?.Invoke();
                break;
             case  Enemy:
                FragmentEnemyDied?.Invoke();
                break;
        }
    }

    private float RandomSpeed(float speed)
    {
        float randomSpeed = UnityEngine.Random.Range(speed - speed / 3, speed + speed / 3);
        return randomSpeed;
    }

    private void OnDestroy()
    {
        _timerActive.OnTimerFinish -= SpawnActiveEnemy;
        _timerSplittable.OnTimerFinish -= SpawnSplittableEnemy;
        _gameSettings.OnGameQuit -= OnDestroy;
    }
}

