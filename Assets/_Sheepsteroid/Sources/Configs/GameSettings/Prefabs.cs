using UnityEngine;

[System.Serializable]
public class Prefabs
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _laser;
    [SerializeField] private GameObject _activeEnemy;
    [SerializeField] private GameObject _passiveEnemy;
    [SerializeField] private GameObject[] _enemyFragments;

    public GameObject Player { get => _player; }
    public GameObject Bullet { get => _bullet; }
    public GameObject Laser { get => _laser; }
    public GameObject ActiveEnemy { get => _activeEnemy; }
    public GameObject PassiveEnemy { get => _passiveEnemy; }
    public GameObject[] EnemyFragments { get => _enemyFragments; }
}

