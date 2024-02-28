public interface IUIManager
{
    public void AddScreen(IScreenManager screenManager, ApplicationManager.AppStates appStateKey);
    public void RemoveScreen(ApplicationManager.AppStates appStateKey);
    void ShowPanel(ApplicationManager.AppStates stateKey);
    void HidePanel(ApplicationManager.AppStates stateKey);
    public void UpdateUI();   
}
