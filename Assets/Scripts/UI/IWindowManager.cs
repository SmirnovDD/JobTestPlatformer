namespace JobTest.UI
{
    public interface IWindowManager
    {
        void SetWindows(UIWindow[] windows);
        void ShowMenu(MenuType type);
        void HideLastChosenMenu();
    }
}