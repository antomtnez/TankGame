using UnityEngine;

public class FinishGame : ApplicationState
{
    public FinishGame(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
    }

    public override ApplicationManager.AppStates GetNextState(){
        return ApplicationManager.AppStates.CloseGame;
    }

    public override void UpdateState()
    {}
}
