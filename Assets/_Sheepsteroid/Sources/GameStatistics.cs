using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class GameStatistics : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private UIGameOver _uiGameOver;
    [SerializeField] private UIController _uiController;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private PlayerRecords _playerRecords;

    private IPlayer _player;
    private EnemiesViewModel _enemies;
    private WeaponViewModel _weapon;
    private Rigidbody2D _playerRB2D;

    public void Init(
         PlayerViewModel playerViewModel,
         EnemiesViewModel enemiesViewModel,
         WeaponViewModel weaponViewModel)
    {
        _player = playerViewModel.PlayerVM.Model;
        _enemies = enemiesViewModel;
        _weapon = weaponViewModel;
        playerViewModel.PlayerVM.View.GetGameObject()
            .TryGetComponent<Rigidbody2D>(out _playerRB2D);

        _playerRecords.Clean();

        _weapon.OnLaserCapacityChanged += SetLaserCount;
        _enemies.ActiveEnemyDied += SetActiveEnemy;
        _enemies.SplittableEnemyDied += SetSplittableEnemy;
        _enemies.FragmentEnemyDied += SetFragmentEnemy;
        _gameManager.OnGameStop += GameOver;
    }

    private void SetLaserCount(int count)
    {
        _uiController.SetLaserCount(count);
    }

    public void StartStats()
    {
        StartCoroutine(UpdateUISlowly());
    }

    public IEnumerator UpdateUISlowly()
    {
        while (true)
        {
            _uiController.SetPlayerStats(
                _player.Position, _player.Rotation, _playerRB2D.velocity.magnitude);

            if (_weapon.LaserRollbackTime > 0)
                _uiController.SetRollbackTime(_weapon.LaserRollbackTime);

            yield return new WaitForSeconds(0.1f);
        }
    }

    private void SetActiveEnemy()
    {
        _playerRecords.ActiveEnemyDestroyed++;
        _uiController.SetActiveEnemy(_playerRecords.ActiveEnemyDestroyed);
    }

    private void SetSplittableEnemy()
    {
        _playerRecords.SplittableEnemyDestroyed++;
        _uiController.SetSplittableEnemy(_playerRecords.SplittableEnemyDestroyed);
    }

    private void SetFragmentEnemy()
    {
        _playerRecords.FragmentEnemyDestroyed++;
        _uiController.SetFragmentEnemy(_playerRecords.FragmentEnemyDestroyed);
    }

    public void GameOver()
    {
        StopAllCoroutines();
    }

    private void OnDestroy()
    {
        _gameManager.OnGameStop -= GameOver;
        _weapon.OnLaserCapacityChanged -= SetLaserCount;
        _enemies.ActiveEnemyDied -= SetActiveEnemy;
        _enemies.SplittableEnemyDied -= SetSplittableEnemy;
        _enemies.FragmentEnemyDied -= SetFragmentEnemy;
    }
}
