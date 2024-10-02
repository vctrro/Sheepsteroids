using System.Collections;
using UnityEngine;
using Model;

public class ViewModelPair<T1, T2> where T1 : IObject2D where T2 : IObject2DView
{
    private T1 _model;
    private T2 _view;

    public T1 Model { get => _model; }
    public T2 View { get => _view; }

    public ViewModelPair(T1 model, T2 view, GameSettings gameSettings)
    {
        _model = model;
        _view = view;
        _view.GetGameObject().SetActive(false);
        Pair(gameSettings);
    }

    protected virtual void Pair(GameSettings gameSettings)
    {
        Model.OnInit = View.Init;
        Model.OnRotate = View.Rotate;

        if (Model is IMovable && View is IMovableView)
        {
            (Model as IMovable).OnMove = (View as IMovableView).Move;
            (Model as IMovable).OnTeleport = (View as IMovableView).Teleport;
            (Model as IMovable).OnCheckBorder = gameSettings.BorderControl.CheckBorder;
            (View as IMovableView).OnUpdate = (Model as IMovable).Update;
        }
        if (Model is ICollidable && View is ICollidableView)
        {
            (View as ICollidableView).OnCollision = (Model as ICollidable).Collision;
        }
        if (Model is IEnemy && View is IEnemyView)
        {
            (View as IEnemyView).OnCollision = (Model as IEnemy).Collision;
        }
        if (Model is IProjectile && View is IProjectileView)
        {
            (Model as IProjectile).OnShoot = (View as IProjectileView).Shoot;
        }
    }
}

