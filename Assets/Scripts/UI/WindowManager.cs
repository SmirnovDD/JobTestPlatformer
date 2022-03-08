using System.Linq;
using UnityEngine;

namespace JobTest.UI
{
    public class WindowManager : MonoBehaviour, IWindowManager
    {
        private UIWindow[] _windows;
        private UIWindow _lastChosenMenu;

        public void SetWindows(UIWindow[] windows)
        {
            _windows = windows;
        }
        
        public void HideLastChosenMenu()
        {
            _lastChosenMenu.Hide();
        }
        
        public void ShowMenu(MenuType type)
        {
            if (_lastChosenMenu != null)
                _lastChosenMenu.Hide();
            _lastChosenMenu = _windows.First(el => el.WindowType == type);
            _lastChosenMenu.Show();
        }
    }
}