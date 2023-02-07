using System;
using UnityEngine;
using Model;

public interface ICollidableView
{
    public Func<ICollidable> OnCollision { get; set; }
}
