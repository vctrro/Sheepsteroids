using System;
using UnityEngine;
using Model;

public interface IEnemyView : IObject2DView, IMovableView
{
    public Action<ICollidable> OnCollision { get; set; }
}

