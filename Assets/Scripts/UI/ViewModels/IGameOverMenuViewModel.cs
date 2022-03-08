using JobTest.Time;
using UnityEngine.SceneManagement;

namespace JobTest.UI
{
    public interface IGameOverMenuViewModel : ILevelMenuViewModel
    {
        public void OnStartGameButtonClick();
    }
    
    public class GameOverMenuViewModel : IGameOverMenuViewModel
    {
        private IWindowManager _windowManager;
        private IGameTime _gameTime;

        public GameOverMenuViewModel(IWindowManager windowManager, IGameTime gameTime)
        {
            _gameTime = gameTime;
            _windowManager = windowManager;
        }

        public void OnExitToMainMenuButtonClick()
        {
            _windowManager.ShowMenu(MenuType.Main);
        }

        public void OnStartGameButtonClick()
        {
            SceneManager.LoadScene(0); //once again, only for this test
        }

        public void Dispose()
        {
        }
    }
}