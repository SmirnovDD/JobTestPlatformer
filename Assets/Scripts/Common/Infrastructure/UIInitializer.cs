using System;
using JobTest.Input;
using JobTest.Time;
using JobTest.UI;
using UnityEngine;
using Zenject;

namespace JobTest.Common.Infrastructure
{
    public class UIInitializer : MonoBehaviour
    {
        private IWindowManager _windowManager;
        private IGameTime _gameTime;
        private MainMenu _mainMenu;
        private PauseMenu _pauseMenu;
        private GameOverMenu _gameOverMenu;
        private IInputController _inputController;
        private UIWindow[] _windows;
        
        [Inject]
        public void Init(IWindowManager windowManager, IGameTime gameTime, IInputController inputController)
        {
            _inputController = inputController;
            _gameTime = gameTime;
            _windowManager = windowManager;
        }
        
        private void Awake()
        {
            _mainMenu = GetComponentInChildren<MainMenu>();
            _pauseMenu = GetComponentInChildren<PauseMenu>();
            _gameOverMenu = GetComponentInChildren<GameOverMenu>();

            _windows = new UIWindow [] {_mainMenu, _pauseMenu, _gameOverMenu};
            
            _windowManager.SetWindows(_windows);
            
            SetupWindows();
        }

        private void OnDisable()
        {
            foreach (var window in _windows)
            {
                window.ViewModel.Dispose();
            }
        }

        private void SetupWindows()
        {
            SetupMainMenu();
            SetupPauseMenu();
            SetupGameOverMenu();
        }

        private void SetupMainMenu()
        {
            var mainMenuViewModel = new MainMenuViewModel(_windowManager, _gameTime);
            _mainMenu.Setup(mainMenuViewModel);
        }
        
        private void SetupPauseMenu()
        {
            var pauseMenuViewModel = new PauseMenuViewModel(_windowManager, _gameTime, _inputController);
            _pauseMenu.Setup(pauseMenuViewModel);
        }

        private void SetupGameOverMenu()
        {
            var gameOverMenuViewModel = new GameOverMenuViewModel(_windowManager, _gameTime);
            _gameOverMenu.Setup(gameOverMenuViewModel);
        }
    }
}