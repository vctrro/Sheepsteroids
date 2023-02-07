using System;
using UnityEngine;
using Model;

public interface IProjectileView : IObject2DView, ICollidableView
{
    public void Shoot();
}

