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
        var force = _direction * speed / (_rigidbody2D.angularVelocity + 1f);
        _rigidbody2D.AddForce(force);
    }

    public void Teleport(Vector2 newPosition)
    {
        transform.position = newPosition; //think
    }
}

