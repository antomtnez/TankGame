public class TankBattleGameScreen : BaseScreenManager
{
    private TankBattleGamePresenter tankBattleGamePresenter;

    public override void InitializeScreen()
    {
        stateAssociatedToScreen = ApplicationManager.AppStates.EnemyMoveTurn;
        tankBattleGamePresenter = new TankBattleGamePresenter(ApplicationManager.GameManager, this.gameObject.GetComponent<TankBattleGameView>());
    }

    public override void UpdateScreen()
    {
        tankBattleGamePresenter.OnPlayerHealthChanged();
        tankBattleGamePresenter.OnEnemyHealthChanged();
    }
}
