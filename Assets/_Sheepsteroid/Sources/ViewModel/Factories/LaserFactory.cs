using UnityEngine;
using Model;

public class LaserFactory : ViewModelFactory<ILaser, ILaserView>
{
    private IPlayer _player;
    private IPlayerView _playerView;

    public LaserFactory(
        GameSettings gameSettings,
        ViewModelPair<IPlayer, IPlayerView> playerViewModel) : base(gameSettings)
    {
        _player = playerViewModel.Model;
        _playerView = playerViewModel.View;
    }

    public override ILaser CreateModel()
    {
        return new Laser(_player);
    }

    public override ILaserView CreateView()
    {
        return MonoBehaviour
            .Instantiate(GameSettings.Prefabs.Laser, _playerView.GetGameObject().transform)
            .GetComponent<ILaserView>();
    }

    public override ViewModelPair<ILaser, ILaserView> CreateViewModel(ILaser model, ILaserView view)
    {
        return new ViewModelPairPoolable<ILaser, ILaserView>(model, view, GameSettings);
    }
}
