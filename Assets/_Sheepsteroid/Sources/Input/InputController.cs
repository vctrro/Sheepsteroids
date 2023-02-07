using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Model;
using static UnityEngine.InputSystem.InputAction;

public class InputController 
{
    private GameSettings _gameSettings;
    private PlayerInput _input;

    public event Action OnMove;
    public event Action OnShoot;
    public event Action OnLaserShoot;
    public event Action<float> OnRotate;


    public InputController(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;

        Start();
    }

    private void PlayerMove()
    {
        if (_input.Main.Move.phase == InputActionPhase.Performed)
        {
            OnMove?.Invoke();
        }

        float angle = _input.Main.Rotate.ReadValue<float>() * _gameSettings.Player.RotationSpeed;
        OnRotate?.Invoke(angle);
    }

    private void Start()
    {
        _input = new PlayerInput();
        _input.Enable();
        _input.Main.Gun.performed += Shoot;
        _input.Main.LaserGun.performed += LaserShoot;

        _gameSettings.OnGameQuit += OnDestroy;
        Timer.OnTimeChanged += PlayerMove;
    }

    private void OnDestroy()
    {
        Timer.OnTimeChanged -= PlayerMove;
        _gameSettings.OnGameQuit -= OnDestroy;

        _input.Disable();
        _input.Main.Gun.performed -= Shoot;
        _input.Main.LaserGun.performed -= LaserShoot;
    }

    public void Shoot(CallbackContext callbackContext)
    {
        OnShoot?.Invoke();
    }

    public void LaserShoot(CallbackContext callbackContext)
    {
        OnLaserShoot?.Invoke();
    }


}
