using UnityEngine;

public class PlayerMoveTurn : ApplicationState
{
    public PlayerMoveTurn(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
        ApplicationManager.GameManager.OnPlayerMovementEnded += ApplicationManager.Instance.ChangeToNextState;
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
        ApplicationManager.GameManager.OnPlayerMovementEnded -= ApplicationManager.Instance.ChangeToNextState;
    }

    public override ApplicationManager.AppStates GetNextState(){
        return ApplicationManager.AppStates.PlayerAttackTurn;
    }

    public override void UpdateState()
    {
        ApplicationManager.GameManager.PlayerMove();
        ApplicationManager.GameManager.IsPlayerMovementEnded();

        if(Input.GetKeyDown(KeyCode.Q)) ApplicationManager.Instance.ChangeToNextState();
    }
}
