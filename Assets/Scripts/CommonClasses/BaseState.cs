using System;

public abstract class BaseState<EState> where EState : Enum
{
    public BaseState(EState stateKey){
        this.stateKey = stateKey;
    }
    public EState stateKey{ get; private set;}
    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    public abstract EState GetNextState();
}
