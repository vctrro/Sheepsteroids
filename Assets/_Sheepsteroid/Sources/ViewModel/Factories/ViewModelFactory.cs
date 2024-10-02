using System;
using UnityEngine;
using Model;

public abstract class ViewModelFactory<T1, T2> where T1 : IObject2D where T2 : IObject2DView
{
    private GameSettings _gameSettings;
    protected GameSettings GameSettings { get => _gameSettings; }

    public ViewModelFactory(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
    }

    public abstract T1 CreateModel();
    public abstract T2 CreateView();
    public abstract ViewModelPair<T1, T2> CreateViewModel(T1 model, T2 view);
}
