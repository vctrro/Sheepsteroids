using System;
using UnityEngine;
using UnityEngine.Pool;
using Model;

public class MultiGun<T1, T2, T3> : SingleGun<T1, T2, T3> where T1 : IGun where T2 : IProjectile where T3 : IProjectileView
{
    private ViewModelSpawner<T2, T3> _projectileSpawner;

    public MultiGun(T1 gun, ViewModelFactory<T2, T3> projectileFactory) : base(gun, projectileFactory)
    {   
    }

    protected override void Init(ViewModelFactory<T2, T3> projectileFactory)
    {
        _projectileSpawner = new ViewModelSpawner<T2, T3>(projectileFactory);
    }

    public override T1 GetGun(Vector2 position, float rotation, float lifeTime)
    {
        _projectile = _projectileSpawner.Get;
        base.GetGun(position, rotation, lifeTime);
        return _gun;
    }
}

