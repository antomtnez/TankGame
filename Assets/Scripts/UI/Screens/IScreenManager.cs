public interface IScreenManager
{
    public void InitializeScreen();
    public void UpdateScreen();
    public void ShowPanel();
    public void HidePanel();
    public ApplicationManager.AppStates GetAssociatedState();
}
