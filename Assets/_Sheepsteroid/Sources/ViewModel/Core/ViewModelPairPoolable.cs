using UnityEngine;
using System.Collections;
using Model;
using UnityEngine.Pool;

public class ViewModelPairPoolable<T1, T2> : ViewModelPair<T1, T2>, IPoolable<ViewModelPair<T1, T2>> where T1 : IObject2D where T2 : IObject2DView
{
    private ObjectPool<ViewModelPair<T1, T2>> _viewModelPool;

    public ViewModelPairPoolable(T1 model, T2 view, GameSettings gameSettings) : base(model, view, gameSettings)
    {
    }

    public void SetPool(ObjectPool<ViewModelPair<T1, T2>> pool)
    {
        _viewModelPool = pool;
    }

    public void Relise()
    {
        _viewModelPool?.Release(this);
    }

    protected override void Pair(GameSettings gameSettings)
    {
        base.Pair(gameSettings);
        Model.OnDestroy = Relise;
    }
}

