using UnityEngine;

public class EnemyAttackTurn : ApplicationState
{
    public EnemyAttackTurn(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState()
    {
        Debug.Log($"Acabo de entrar a {stateKey}");
        ApplicationManager.UIManager.ShowPanel(this.stateKey);
        ApplicationManager.GameManager.EnemyAttack();
        ProjectilePool.Instance.OnProjectileReturned += ApplicationManager.Instance.ChangeToNextState;
    }

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
        ApplicationManager.UIManager.UpdateUI();
        ProjectilePool.Instance.OnProjectileReturned -= ApplicationManager.Instance.ChangeToNextState;
    }

    public override ApplicationManager.AppStates GetNextState(){
        if(ApplicationManager.GameManager.IsPlayerDead()) return ApplicationManager.AppStates.FinishGame;
        return ApplicationManager.AppStates.EnemyMoveTurn;
    }

    public override void UpdateState()
    {}
}
