using UnityEngine;
using UnityEngine.UI;

namespace JobTest.UI
{
    public class PauseMenu : UIWindow
    {
        public override MenuType WindowType => MenuType.Pause;
        
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _toMainMenuButton;
        
        public override void Setup(IViewModel viewModel)
        {
            base.Setup(viewModel);
            var model = viewModel as IPauseMenuViewModel;
            _resumeButton.onClick.AddListener(() => model.OnResumeButtonClick());
            _toMainMenuButton.onClick.AddListener(() => model.OnExitToMainMenuButtonClick());
        }

        private void OnDestroy()
        {
            _resumeButton.onClick.RemoveAllListeners();
            _toMainMenuButton.onClick.RemoveAllListeners();
        }
    }
}