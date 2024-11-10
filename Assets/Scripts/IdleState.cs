using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    private Vector3 input;
    public override void EnterState(StateManager player)
    {
        
    }

    public override void UpdateState(StateManager player)
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.z = Input.GetAxisRaw("Vertical");
        if (input != Vector3.zero)
        {
            ExitState(player);
        }
    }
    public override void ExitState(StateManager player)
    {
        player.SwitchState(player.movementState);
    }
    public override void OnCollisionEnter(StateManager player)
    {
        
    }
}
