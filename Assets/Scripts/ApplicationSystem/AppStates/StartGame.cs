using UnityEngine;

public class StartGame : ApplicationState
{
    public StartGame(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
        ApplicationManager.UIManager.HidePanel(this.stateKey);
    }

    public override ApplicationManager.AppStates GetNextState(){
        return ApplicationManager.AppStates.EnemyMoveTurn;
    }

    public override void UpdateState(){}
}
