using System;
using Model;
using UnityEngine;
using UnityEngine.Pool;

public class ViewModelSpawner<T1, T2> where T1 : IObject2D where T2 : IObject2DView 
{
    private ObjectPool<ViewModelPair<T1, T2>> _viewModelPool;
	private ViewModelFactory<T1, T2> _viewModelFactory;

    public ViewModelPair<T1, T2> Get => _viewModelPool.Get();
    public int Count => _viewModelPool.CountActive;

    public ViewModelSpawner(ViewModelFactory<T1, T2> viewModelFactory)
	{
        _viewModelFactory = viewModelFactory;
        _viewModelPool = new(CreateObject, OnGetObject, OnReliseObject, OnDestroyObject);
    }

    private ViewModelPair<T1, T2> CreateObject()
    {
        T1 model = _viewModelFactory.CreateModel();
        T2 view  = _viewModelFactory.CreateView();
        view.GetGameObject().SetActive(false);

        var viewModelPair = _viewModelFactory.CreateViewModel(model, view);
        if (viewModelPair is ViewModelPairPoolable<T1, T2>)
        {
            (viewModelPair as ViewModelPairPoolable<T1, T2>).SetPool(_viewModelPool);
        }
        else
        {
            throw new InvalidOperationException($"{viewModelPair} must be as ViewModelPairPoolable here!");
        }

        return viewModelPair;
    }

    private void OnGetObject(ViewModelPair<T1, T2> viewModelPair)
    {
        viewModelPair.View.GetGameObject().SetActive(true);
    }

    private void OnReliseObject(ViewModelPair<T1, T2> viewModelPair)
    {
        viewModelPair.View.Disable();
    }

    private void OnDestroyObject(ViewModelPair<T1, T2> viewModelPair)
    {
        UnityEngine.Object.Destroy(viewModelPair.View.GetGameObject());
    }
}

