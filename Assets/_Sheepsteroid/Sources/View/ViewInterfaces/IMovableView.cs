using System;
using UnityEngine;
using Model;

public interface IMovableView
{
    public Action<Vector2> OnUpdate { get; set; }

    public void Teleport(Vector2 newPosition);
    public void Move(float speed);
}

