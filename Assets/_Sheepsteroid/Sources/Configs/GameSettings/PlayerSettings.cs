using UnityEngine;

[System.Serializable]
public class PlayerSettings
{
    [SerializeField] private Vector2 spawnPosition = Vector2.zero;
    [SerializeField] private float speed = 2;
    [Range(1.0f, 5.0f)]
    [SerializeField] private float rotationSpeed = 1f;

    public Vector2 SpawnPosition { get => spawnPosition; }
    public float Speed { get => speed; }
    public float RotationSpeed { get => rotationSpeed; }
}

