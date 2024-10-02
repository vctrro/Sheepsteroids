using System;
using System.Collections;
using UnityEngine;
using Model;

public class PlayerView : MovableView, IPlayerView
{
    [SerializeField] Transform _sprite;
    public Func<ICollidable> OnCollision { get; set; }

    public override void Rotate(float rotation)
    {
        _sprite.rotation = Quaternion.Euler(0, 0, rotation);
        _direction = _sprite.up;
    }
}

