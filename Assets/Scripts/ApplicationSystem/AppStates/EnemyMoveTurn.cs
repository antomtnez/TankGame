using UnityEngine;

public class EnemyMoveTurn : ApplicationState
{
    public EnemyMoveTurn(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
        ApplicationManager.GameManager.OnEnemyMovementEnded += ApplicationManager.Instance.ChangeToNextState;
        ApplicationManager.GameManager.EnemyMove();
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
        ApplicationManager.GameManager.OnEnemyMovementEnded -= ApplicationManager.Instance.ChangeToNextState;
    }

    public override ApplicationManager.AppStates GetNextState(){
        return ApplicationManager.AppStates.PlayerMoveTurn;
    }

    public override void UpdateState()
    {
        ApplicationManager.GameManager.IsEnemyMovementEnded();
    }
}
