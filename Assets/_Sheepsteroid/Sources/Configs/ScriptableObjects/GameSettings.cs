using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Sheepsteroid/GameSettings", order = 0)]
public class GameSettings : ScriptableObject
{
    [Header("----- Game Settings -----")]
    [SerializeField] private PlayerSettings _player;
    [Space(5)]
    [SerializeField] private WeaponSettings _weapon;
    [Space(5)]
    [SerializeField] private ActiveEnemySettings _activeEnemy;
    [Space(5)]
    [SerializeField] private PassiveEnemySettings _passiveEnemy;
    [Space(5)]
    [SerializeField] private Prefabs _prefabs;

    public Action OnGameQuit { get; set; }
    public Action OnGameOver { get; set; }

    public PlayerSettings Player { get => _player; }
    public WeaponSettings Weapon { get => _weapon; }
    public ActiveEnemySettings ActiveEnemy { get => _activeEnemy; }
    public PassiveEnemySettings PassiveEnemy { get => _passiveEnemy; }
    public BorderControl BorderControl { get => _borderControl; }
    public Prefabs Prefabs { get => _prefabs; }

    private BorderControl _borderControl;
}
