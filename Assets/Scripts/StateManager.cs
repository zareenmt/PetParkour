using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    BaseState currentState;
    public IdleState idleState = new IdleState();
    public MovementState movementState = new MovementState();
    public JumpState jumpState = new JumpState();
    
    void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
