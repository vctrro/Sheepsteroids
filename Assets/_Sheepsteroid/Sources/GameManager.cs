using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public event Action OnGameQuit;
    public event Action OnGameStop;

    [SerializeField] private Camera _camera;
    [SerializeField] private GameStatistics _gameStats;
    [SerializeField] private GameSettings _gameSettings;

    public GameSettings GameSettings { get => _gameSettings; }

    private InputController _inputController;
    private PlayerViewModel _playerViewModel;
    private EnemiesViewModel _enemyViewModel;
    private WeaponViewModel _weaponViewModel;

    private bool _gameStopped = false;

    private void Awake()
    {
        _camera = Camera.main;
        GameSetup();
    }

    private void Start()
    {
        GameInit();
        _gameStats.Init(_playerViewModel, _enemyViewModel, _weaponViewModel);
        _gameStats.StartStats();
    }

    private void Update()
    {
        if (_gameStopped) return;
        Model.Timer.DeltaTime = Time.deltaTime;
    }

    private void GameInit()
    {
        _inputController = new InputController(_gameSettings);
        _playerViewModel = new PlayerViewModel(_gameSettings, _inputController);
        _enemyViewModel = new EnemiesViewModel(_gameSettings, _playerViewModel.PlayerVM.Model);
        _weaponViewModel = new WeaponViewModel(
            _gameSettings, _playerViewModel.PlayerVM, _inputController);

        OnGameQuit += _gameSettings.OnGameQuit;
        OnGameStop += _gameSettings.OnGameOver;
        _playerViewModel.OnGameOver = GameOver;
    }

    private void GameSetup()
    {
        float topSide, bottomSide, rightSide, leftSide;

        var topLeftCorner = (Vector2)_camera.ScreenToWorldPoint(
            new Vector3(0, _camera.pixelHeight, _camera.nearClipPlane));
        var bottomRightCorner = (Vector2)_camera.ScreenToWorldPoint(
            new Vector3(_camera.pixelWidth, 0, _camera.nearClipPlane));
        (topSide, leftSide) = (topLeftCorner.y, topLeftCorner.x);
        (bottomSide, rightSide) = (bottomRightCorner.y, bottomRightCorner.x);

        _gameSettings.BorderControl.Set(topSide, bottomSide, leftSide, rightSide);
    }

    private void GameOver()
    {
        _gameStopped = true;
        OnGameStop?.Invoke();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        OnGameQuit?.Invoke();
        OnGameQuit -= _gameSettings.OnGameQuit;
        //Debug.Log(_gameSettings.OnGameQuit.GetInvocationList().Length);
    }
}
