using UnityEngine;

public abstract class EnemySettings
{
    [SerializeField] private float _timeToSpawn = 10.0f;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private int _maxQuantity = 10;
    [SerializeField] private int _points = 1;

    public float Speed { get => _speed; }
    public int MaxQuantity { get => _maxQuantity; }
    public float TimeToSpawn { get => _timeToSpawn; }
    public int Points { get => _points; }
}

