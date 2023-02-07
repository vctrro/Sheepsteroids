using UnityEngine;
using Model;

public class BulletFactory : ViewModelFactory<IBullet, IBulletView>
{
    public BulletFactory(GameSettings gameSettings) : base(gameSettings)
    {
    }

    public override IBullet CreateModel()
    {
        return new Bullet();
    }

    public override IBulletView CreateView()
    {
        return MonoBehaviour.Instantiate(GameSettings.Prefabs.Bullet).GetComponent<BulletView>();
    }

    public override ViewModelPair<IBullet, IBulletView> CreateViewModel(IBullet model, IBulletView view)
    {
        return new ViewModelPairPoolable<IBullet, IBulletView>(model, view, GameSettings);
    }
}
