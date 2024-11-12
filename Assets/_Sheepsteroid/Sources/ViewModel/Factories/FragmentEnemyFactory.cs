using UnityEngine;
using Model;

public class FragmentEnemyFactory : ViewModelFactory<IEnemy, IEnemyView>
{
    private readonly int _maxNumberOfFragments;
    private int _numberOfFragments;
    private int NumberOfFragments
    {
        get => _numberOfFragments;
        set => Mathf.Repeat(_numberOfFragments + value, _maxNumberOfFragments);
    }

    public FragmentEnemyFactory(GameSettings gameSettings, int numberOfFragments) : base(gameSettings)
    {
        _maxNumberOfFragments = numberOfFragments;
    }

    public override IEnemy CreateModel()
    {
        return new Enemy();
    }

    public override IEnemyView CreateView()
    {
        var enemyWiew = MonoBehaviour.Instantiate(GameSettings.Prefabs.EnemyFragments[NumberOfFragments]).GetComponent<EnemyView>();
        NumberOfFragments++;
        return enemyWiew;
    }

    public override ViewModelPair<IEnemy, IEnemyView> CreateViewModel(IEnemy model, IEnemyView view)
    {
        return new ViewModelPairPoolable<IEnemy, IEnemyView>(model, view, GameSettings);
    }
}
