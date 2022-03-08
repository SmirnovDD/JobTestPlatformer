using UnityEngine;

namespace JobTest.UI
{
    public abstract class UIWindow : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        public virtual MenuType WindowType { get; }
        public IViewModel ViewModel { get; private set; }
        public virtual void Show()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        public virtual void Hide()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        public virtual void Setup(IViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}