using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerRecords", menuName = "Sheepsteroid/PlayerRecords", order = 0)]
public class PlayerRecords : ScriptableObject
{
    [SerializeField] private GameSettings _gameSettings;

    private int _activeEnemyDestroyed = 0;
    private int _splittableEnemyDestroyed = 0;
    private int _fragmentEnemyDestroyed = 0;

    public int ActiveEnemyDestroyed { get => _activeEnemyDestroyed; set => _activeEnemyDestroyed = value; }
    public int SplittableEnemyDestroyed { get => _splittableEnemyDestroyed; set => _splittableEnemyDestroyed = value; }
    public int FragmentEnemyDestroyed { get => _fragmentEnemyDestroyed; set => _fragmentEnemyDestroyed = value; }

    public int Points =>
        _activeEnemyDestroyed * _gameSettings.ActiveEnemy.Points +
        _splittableEnemyDestroyed * _gameSettings.PassiveEnemy.Points +
        _fragmentEnemyDestroyed * _gameSettings.PassiveEnemy.FragmentPoints;

    public void Clean()
    {
        _activeEnemyDestroyed = 0;
        _splittableEnemyDestroyed = 0;
        _fragmentEnemyDestroyed = 0;
    }
}