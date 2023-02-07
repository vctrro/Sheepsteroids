using System;
using UnityEngine;
using UnityEngine.Pool;
using Model;

public class SingleGun<T1, T2, T3> where T1 : IGun where T2 : IProjectile where T3 : IProjectileView
{
    protected readonly T1 _gun;
    protected ViewModelPair<T2, T3> _projectile;

    public T1 Gun => _gun;

    public SingleGun(T1 gun, ViewModelFactory<T2, T3> projectileFactory)
    {
        _gun = gun;
        Init(projectileFactory);
    }

    protected virtual void Init(ViewModelFactory<T2, T3> projectileFactory)
    {
        var model = projectileFactory.CreateModel();
        var view = projectileFactory.CreateView();
        _projectile = projectileFactory.CreateViewModel(model, view);

        _projectile.Model.OnDestroy = () => {
            _projectile.View.Disable();
        };
    }

    public virtual T1 GetGun(Vector2 position, float rotation, float lifeTime)
    {
        _projectile.View.GetGameObject().SetActive(false);
        _projectile.Model.LifeTime = lifeTime;
        _projectile.Model.Init(position, rotation);
        _gun.Projectile = _projectile.Model;
        return _gun;
    }
}

