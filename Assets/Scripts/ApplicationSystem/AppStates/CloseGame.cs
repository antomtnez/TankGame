using UnityEngine;

public class CloseGame : ApplicationState
{
    public CloseGame(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        Application.Quit();
    }
}
