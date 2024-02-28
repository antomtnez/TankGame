using UnityEngine;

public class MainMenuScreen : BaseScreenManager
{
    public override void InitializeScreen()
    {
        stateAssociatedToScreen = ApplicationManager.AppStates.StartGame;
    }

    public override void UpdateScreen()
    {
        base.UpdateScreen();
    }
}
