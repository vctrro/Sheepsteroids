using System;
using UnityEngine;
using Model;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class MovableView : Object2DView, IMovableView
{
    public Action<Vector2> OnUpdate { get; set; }

    private Rigidbody2D _rigidbody2D;

    protected virtual void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        OnUpdate?.Invoke(transform.position);
    }

    public void Move(float speed)
    {
        _rigidbody2D.AddForce(_direction * speed);
    }

    public void Teleport(Vector2 newPosition)
    {
        transform.position = newPosition; //think
    }
}

