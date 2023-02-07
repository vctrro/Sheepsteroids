using UnityEngine;
using Model;

public class PlayerFactory : ViewModelFactory<IPlayer, IPlayerView>
{
    public PlayerFactory(GameSettings gameSettings) : base(gameSettings)
    {
    }

    public override IPlayer CreateModel()
    {
        return new Player();
    }

    public override IPlayerView CreateView()
    {
        return MonoBehaviour.Instantiate(GameSettings.Prefabs.Player).GetComponent<IPlayerView>();
    }

    public override ViewModelPair<IPlayer, IPlayerView> CreateViewModel(IPlayer model, IPlayerView view)
    {
        return new ViewModelPair<IPlayer, IPlayerView>(model, view, GameSettings);
    }
}
