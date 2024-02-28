using UnityEngine;

public class TankBattleGamePresenter
{
    private IGameManager gameManager;
    private TankBattleGameView battleGameView;

    public TankBattleGamePresenter(IGameManager gameManager, TankBattleGameView battleGameView)
    {
        this.gameManager = gameManager;
        this.battleGameView = battleGameView;
        InitializeView();
    }

    void InitializeView()
    {
        battleGameView.SetPlayerMaxHealth(gameManager.GetPlayerTank().GetMaxHealth());
        battleGameView.SetEnemyMaxHealth(gameManager.GetEnemyTank().GetMaxHealth());
    }

    public void OnPlayerHealthChanged()
    {
        battleGameView.SetPlayerCurrentHealth(gameManager.GetPlayerTank().GetHealth());
    }

    public void OnEnemyHealthChanged()
    {
        battleGameView.SetEnemyCurrentHealth(gameManager.GetEnemyTank().GetHealth());
    }
}
