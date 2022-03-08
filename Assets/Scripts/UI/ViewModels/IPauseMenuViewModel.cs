using JobTest.Input;
using JobTest.Time;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace JobTest.UI
{
    public interface IPauseMenuViewModel : ILevelMenuViewModel
    {
        public void OnResumeButtonClick();
    }
    
    public class PauseMenuViewModel : IPauseMenuViewModel
    {
        private IWindowManager _windowManager;
        private IGameTime _gameTime;
        private InputAction _showPauseMenu;
        public PauseMenuViewModel(IWindowManager windowManager, IGameTime gameTime, IInputController inputController)
        {
            _gameTime = gameTime;
            _windowManager = windowManager;
            _showPauseMenu = inputController.InputControls.Gameplay.ShowPauseMenu;
            _showPauseMenu.started += ShowPauseMenu;
        }

        public void OnExitToMainMenuButtonClick()
        {
            SceneManager.LoadScene(0); //once again, I would do it properly in a real project
        }

        public void OnResumeButtonClick()
        {
            _gameTime.TogglePause(true);
            _windowManager.HideLastChosenMenu();
        }

        private void ShowPauseMenu(InputAction.CallbackContext context)
        {
            _windowManager.ShowMenu(MenuType.Pause);
            _gameTime.TogglePause(true, true);
        }

        public void Dispose()
        {
            _showPauseMenu.started -= ShowPauseMenu;
        }
    }
}