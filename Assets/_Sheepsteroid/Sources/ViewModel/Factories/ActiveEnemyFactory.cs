using UnityEngine;
using Model;

public class ActiveEnemyFactory : ViewModelFactory<IEnemy, IEnemyView>
{
    private IPlayer _player;

    public ActiveEnemyFactory(GameSettings gameSettings, IPlayer player) : base(gameSettings)
    {
        _player = player;
    }

    public override IEnemy CreateModel()
    {
        return new ActiveEnemy((Player)_player);
    }

    public override IEnemyView CreateView()
    {
        return MonoBehaviour.Instantiate(GameSettings.Prefabs.ActiveEnemy).GetComponent<IEnemyView>();
    }

    public override ViewModelPair<IEnemy, IEnemyView> CreateViewModel(IEnemy model, IEnemyView view)
    {
        return new ViewModelPairPoolable<IEnemy, IEnemyView>(model, view, GameSettings);
    }
}
