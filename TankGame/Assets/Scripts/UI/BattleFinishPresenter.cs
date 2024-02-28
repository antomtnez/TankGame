public class BattleFinishPresenter
{
    private IGameManager gameManager;
    private BattleFinishView battleFinishView;

    public BattleFinishPresenter(IGameManager gameManager, BattleFinishView battleFinishView)
    {
        this.gameManager = gameManager;
        this.battleFinishView = battleFinishView;
        InitializeView();
    }

    void InitializeView()
    {
        if(gameManager.IsPlayerDead()) battleFinishView.SetPlayerWinMessage();

        if(gameManager.IsEnemyDead()) battleFinishView.SetEnemyWinMessage();
    }
}
