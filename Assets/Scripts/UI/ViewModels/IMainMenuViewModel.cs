using JobTest.Time;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JobTest.UI
{
    public interface IMainMenuViewModel : IViewModel
    {
        public void OnStartGameButtonClick();
        public void OnExitButtonClick();
    }

    public class MainMenuViewModel : IMainMenuViewModel
    {
        private IWindowManager _windowManager;
        private IGameTime _gameTime;

        public MainMenuViewModel(IWindowManager windowManager, IGameTime gameTime)
        {
            _gameTime = gameTime;
            _windowManager = windowManager;
        }

        public void OnStartGameButtonClick()
        {
            _windowManager.HideLastChosenMenu();
            _gameTime.TogglePause(true);
        }

        public void OnExitButtonClick()
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public void Dispose()
        {
        }
    }
}