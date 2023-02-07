using UnityEngine;
using Model;

public class SplittableEnemyFactory : ViewModelFactory<ISplittableEnemy, IEnemyView>
{
    public SplittableEnemyFactory(GameSettings gameSettings) : base(gameSettings)
    {
    }

    public override ISplittableEnemy CreateModel()
    {
        return new SplittableEnemy();
    }

    public override IEnemyView CreateView()
    {
        return MonoBehaviour.Instantiate(GameSettings.Prefabs.PassiveEnemy).GetComponent<EnemyView>();
    }

    public override ViewModelPair<ISplittableEnemy, IEnemyView> CreateViewModel(ISplittableEnemy model, IEnemyView view)
    {
        return new ViewModelPairPoolable<ISplittableEnemy, IEnemyView>(model, view, GameSettings);
    }
}
