using System;
using UnityEngine;
using System.Collections.Generic;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    [SerializeField]
    protected Dictionary<EState, BaseState<EState>> states = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> currentState;
    public BaseState<EState> CurrentState => currentState;
    public event Action OnStateChanged;

    void Start(){
        currentState.EnterState();
    }
    
    void Update(){
        currentState.UpdateState();
    }

    public void ChangeToNextState(){
        TransitionToState(currentState.GetNextState());
        OnStateChanged?.Invoke();
    }

    void TransitionToState(EState stateKey){
        currentState.ExitState();
        currentState = states[stateKey];
        currentState.EnterState();
    }
}
