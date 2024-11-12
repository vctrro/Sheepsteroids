using System;
using UnityEngine;
using UnityEngine.Pool;
using Model;

public class BulletView : MovableView, IBulletView
{
    public Func<ICollidable> OnCollision { get; set; }

    public void Shoot()
    {
        gameObject.SetActive(true);
    }
}

