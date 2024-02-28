

using UnityEngine;

public class ApplicationState : BaseState<ApplicationManager.AppStates>
{
    public ApplicationState(ApplicationManager.AppStates stateKey) : base(stateKey){}

    public override void EnterState(){}

    public override void ExitState(){
        Debug.Log($"Salimos del {stateKey}");
    }

    public override ApplicationManager.AppStates GetNextState(){
        throw new System.NotImplementedException();
    }

    public override void UpdateState(){}
}
