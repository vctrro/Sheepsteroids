using System;
using UnityEngine;
using Model;

public class PlayerViewModel
{
    public Action OnGameOver;

    private InputController _inputs;
    private GameSettings _gameSettings;
    private PlayerFactory _viewModelFactory;
    private ViewModelPair<IPlayer, IPlayerView> _playerPair;
    private IPlayer _playerModel;
    private IPlayerView _playerView;
    private PlayerSettings _playerSettings;

    public ViewModelPair<IPlayer, IPlayerView> PlayerVM { get => _playerPair; }

    public PlayerViewModel(GameSettings gameSettings, InputController inputs)
    {
        _inputs = inputs;
        _gameSettings = gameSettings;
        Start();
    }

    private void Start()
    {
        _viewModelFactory = new PlayerFactory(_gameSettings);
        _playerPair = CreatePair();

        _inputs.OnMove += Move;
        _inputs.OnRotate += Rotate;
        _gameSettings.OnGameQuit += OnDestroy;
    }

    private ViewModelPair<IPlayer, IPlayerView> CreatePair()
    {
        _playerModel = _viewModelFactory.CreateModel();
        _playerView = _viewModelFactory.CreateView();
        var viewModel = _viewModelFactory.CreateViewModel(_playerModel, _playerView);
        _playerModel.OnDestroy = GameOver;
        _playerView.GetGameObject().SetActive(true);
        return viewModel;
    }

    public void Move()
    {
        _playerModel.Speed = _playerSettings.Speed;
        _playerModel.Move();
    }

    public void Rotate(float angle)
    {
        _playerModel.Rotate(angle * _playerSettings.RotationSpeed);
    }

    private void GameOver()
    {
        _playerView.Disable();
        OnGameOver?.Invoke();
    }

    private void OnDestroy()
    {
        _inputs.OnMove -= Move;
        _inputs.OnRotate -= Rotate;
        _gameSettings.OnGameQuit -= OnDestroy;
    }
}

