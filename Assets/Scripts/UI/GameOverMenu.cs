using UnityEngine;
using UnityEngine.UI;

namespace JobTest.UI
{
    public class GameOverMenu : UIWindow
    {
        public override MenuType WindowType => MenuType.GameOver;
        
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _toMainMenuButton;

        public override void Setup(IViewModel viewModel)
        {
            base.Setup(viewModel);
            var model = viewModel as IGameOverMenuViewModel;
            _startGameButton.onClick.AddListener(() => model.OnStartGameButtonClick());
            _toMainMenuButton.onClick.AddListener(() => model.OnExitToMainMenuButtonClick());
        }

        private void OnDestroy()
        {
            _startGameButton.onClick.RemoveAllListeners();
            _toMainMenuButton.onClick.RemoveAllListeners();
        }
    }
}