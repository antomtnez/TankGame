using UnityEngine;

public class PlayerAttackTurn : ApplicationState
{
    public PlayerAttackTurn(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
        ProjectilePool.Instance.OnProjectileReturned += ApplicationManager.Instance.ChangeToNextState;
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
        ApplicationManager.UIManager.UpdateUI();
        ProjectilePool.Instance.OnProjectileReturned -= ApplicationManager.Instance.ChangeToNextState;
    }

    public override ApplicationManager.AppStates GetNextState(){
        if(ApplicationManager.GameManager.IsPlayerDead()) return ApplicationManager.AppStates.FinishGame;
        return ApplicationManager.AppStates.EnemyAttackTurn;
    }

    public override void UpdateState()
    {
        ApplicationManager.GameManager.PlayerAttack();
        if(Input.GetKeyDown(KeyCode.Q)) ApplicationManager.Instance.ChangeToNextState();
    }
}
