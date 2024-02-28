using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFinishedScreen : BaseScreenManager
{    
    BattleFinishPresenter battleFinishPresenter;

    public override void InitializeScreen()
    {
        stateAssociatedToScreen = ApplicationManager.AppStates.FinishGame;
        battleFinishPresenter = new BattleFinishPresenter(ApplicationManager.GameManager, this.gameObject.GetComponent<BattleFinishView>());
    }

    public override void UpdateScreen()
    {
        base.UpdateScreen();
    }
}
