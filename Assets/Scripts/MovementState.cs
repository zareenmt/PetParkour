using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementState : BaseState
{
    private PlayerAttributes _ref;
    private CharacterController _charControl;
    private Animator _pAnim;
    private Vector3 _movementInput;
    private float speed;
    private bool _isMoving;
    private float rotationFactorPerFrame =15.0f;
    public override void EnterState(StateManager player)
    {
        _ref = player.GetComponent<PlayerAttributes>();
        _isMoving = true;
        _pAnim = _ref.playerAnim;
        _pAnim.SetBool(_ref.movingHash,_isMoving);
        speed = 2.0f;
        _charControl = _ref.charControl;
    }

    public override void UpdateState(StateManager player)
    {
        _movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 posToLookAt;
        posToLookAt.x = _movementInput.x;
        posToLookAt.y = 0.0f;
        posToLookAt.z = _movementInput.z;
        Quaternion currentRotation = player.transform.rotation;
       if (_movementInput != Vector3.zero)
       {
           _movementInput *= speed;
           Quaternion targetRotation = Quaternion.LookRotation(posToLookAt);
           player.transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationFactorPerFrame*Time.deltaTime);
           _charControl.Move(_movementInput*Time.deltaTime);
       }
       else
       {
           _isMoving = false;
           _pAnim.SetBool(_ref.movingHash,_isMoving);
           ExitState(player);
       }

    }
    
    public override void ExitState(StateManager player)
    {
        if (!_isMoving)
        {
            player.SwitchState(player.idleState);
        }
    }

    public override void OnCollisionEnter(StateManager player)
    {
        
    }
}
