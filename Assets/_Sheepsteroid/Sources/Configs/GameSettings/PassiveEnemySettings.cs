using UnityEngine;

[System.Serializable]
public class PassiveEnemySettings : EnemySettings
{
    [SerializeField] private int _fragmentPoints = 1;

    
    public int FragmentPoints { get => _fragmentPoints; }
}

