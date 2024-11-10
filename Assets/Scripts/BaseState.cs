using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    public abstract void EnterState(StateManager player);
    public abstract void UpdateState(StateManager player);
    
    public abstract void ExitState(StateManager player);
    public abstract void OnCollisionEnter(StateManager player);
}