using UnityEngine;
using UnityEngine.UI;

namespace JobTest.UI
{
    public class MainMenu : UIWindow
    {
        public override MenuType WindowType => MenuType.Main;
        
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitButton;

        public override void Setup(IViewModel viewModel)
        {
            base.Setup(viewModel);
            var model = viewModel as IMainMenuViewModel;
            _startGameButton.onClick.AddListener(() => model.OnStartGameButtonClick());
            _exitButton.onClick.AddListener(() => model.OnExitButtonClick());
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveAllListeners();
            _exitButton.onClick.RemoveAllListeners();
        }
    }
}