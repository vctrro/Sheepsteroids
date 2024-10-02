using System;
using UnityEngine;
using Model;

public abstract class Object2DView : MonoBehaviour, IObject2DView
{
    protected Vector2 _direction;

    public virtual void Rotate(float rotation)
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        _direction = transform.up;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    public virtual void Init(Vector2 position, float rotation)
    {
        transform.position = position;
        Rotate(rotation);
    }
}

