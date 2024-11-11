using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : BaseState
{
    private PlayerAttributes _ref;
    private float initalJumpVelocity;
    private float maxJumpHeight = 1.0f;
    private float maxJumpTime = 0.5f;
    private bool isJumping = false;
    private float gravity = -9.8f;
    private Vector3 _movementInput;
    private CharacterController _charControl;

    public override void EnterState(StateManager player)
    {
        float timeToApex = maxJumpTime / 2;
        gravity = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
        initalJumpVelocity = (2 * maxJumpHeight) / timeToApex;
        _movementInput = new Vector3(Input.GetAxis("Horizontal"), -0.5f, Input.GetAxis("Vertical"));
    }

    public override void UpdateState(StateManager player)
    {
        if (!isJumping)
        {
            isJumping = true;
            _movementInput.y = initalJumpVelocity;
            
        }
    }
    public override void ExitState(StateManager player)
    {
        
    }

    public override void OnCollisionEnter(StateManager player)
    {
        
    }
}
