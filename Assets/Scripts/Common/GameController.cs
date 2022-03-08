using JobTest.Player;
using JobTest.Time;
using JobTest.UI;
using UniRx;
using Zenject;

namespace JobTest.GamePlay
{
    public interface IGameController
    {
        void OnGameStart();
    }
    public class GameController : IGameController
    {
        private IGameTime _gameTime;
        private IWindowManager _windowManager;
        private IPlayer _player;

        [Inject]
        public void Init(IGameTime gameTime, IWindowManager windowManager, IPlayer player)
        {
            _player = player;
            _windowManager = windowManager;
            _gameTime = gameTime;
            
            _player.Dead.Subscribe(OnPlayerDied).AddTo(player.Transform);
        }

        public void OnGameStart()
        {
            _gameTime.TogglePause(true, true);
            _windowManager.ShowMenu(MenuType.Main);
        }

        private void OnPlayerDied(bool died)
        {
            if (!died)
                return;
            
            _windowManager.ShowMenu(MenuType.GameOver);
            _gameTime.TogglePause(true, true);
        }
    }
}